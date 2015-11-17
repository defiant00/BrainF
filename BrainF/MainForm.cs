using System;
using System.Collections.Generic;
using System.Reflection;
using System.Reflection.Emit;
using System.Text;
using System.Windows.Forms;

namespace BrainF
{
	public partial class MainForm : Form
	{
		public string Code { get { return textBoxCode.Text; } }
		public string Input { get { return textBoxInput.Text; } }
		public string Output { set { labelOutput.Text = value; } }

		private const string Commands = "<>+-.,[]";
		private int _incDec;

		public MainForm()
		{
			InitializeComponent();
		}

		private void buttonInterpret_Click(object sender, EventArgs e)
		{
			var output = new StringBuilder();
			var sb = new StringBuilder();
			foreach (var c in Code) { if (Commands.IndexOf(c) > -1) { sb.Append(c); } }
			string code = sb.ToString();
			string input = Input;

			int ip = 0, dp = 0;
			byte[] data = new byte[30000];

			while (ip < code.Length)
			{
				switch (code[ip++])
				{
					case '>':
						dp++;
						break;
					case '<':
						dp--;
						break;
					case '+':
						data[dp]++;
						break;
					case '-':
						data[dp]--;
						break;
					case '.':
						output.Append((char)data[dp]);
						break;
					case ',':
						if (input.Length > 0)
						{
							data[dp] = (byte)input[0];
							input = input.Substring(1);
						}
						break;
					case '[':
						if (data[dp] == 0)
						{
							// Jump forward
							int numOpen = 1;
							while (numOpen > 0 && ip < code.Length)
							{
								switch (code[ip++])
								{
									case '[':
										numOpen++;
										break;
									case ']':
										numOpen--;
										break;
								}
							}
						}
						break;
					case ']':
						if (data[dp] != 0)
						{
							// Jump back
							ip -= 2;
							int numOpen = 1;
							while (numOpen > 0 && ip >= 0)
							{
								switch (code[ip--])
								{
									case '[':
										numOpen--;
										break;
									case ']':
										numOpen++;
										break;
								}
							}
							ip += 2; // Move to the command after the [
						}
						break;
				}
			}

			Output = output.ToString();
		}

		private void buttonBuild_Click(object sender, EventArgs e)
		{
			var writeMethod = typeof(Console).GetMethod("Write", new[] { typeof(char) });
			var writeLineMethod = typeof(Console).GetMethod("WriteLine", Type.EmptyTypes);
			var strLenMethod = typeof(string).GetProperty("Length").GetGetMethod();
			var strCharsMethod = typeof(string).GetProperty("Chars").GetGetMethod();
			var substringMethod = typeof(string).GetMethod("Substring", new[] { typeof(int) });

			var OpenLabels = new Stack<System.Reflection.Emit.Label>();
			var CloseLabels = new Stack<System.Reflection.Emit.Label>();

			string name = "CompiledTest";
			var assemblyBuilder = AppDomain.CurrentDomain.DefineDynamicAssembly(new AssemblyName(name), AssemblyBuilderAccess.Save);
			var moduleBuilder = assemblyBuilder.DefineDynamicModule(name + ".exe", true);
			var typeBuilder = moduleBuilder.DefineType("Program", TypeAttributes.Public);
			var main = typeBuilder.DefineMethod("Main", MethodAttributes.Private | MethodAttributes.HideBySig | MethodAttributes.Static, typeof(void),
				new[] { typeof(string[]) });
			main.DefineParameter(1, ParameterAttributes.None, "args");
			var il = main.GetILGenerator();

			il.DeclareLocal(typeof(byte[])).SetLocalSymInfo("data");
			il.DeclareLocal(typeof(int)).SetLocalSymInfo("dp");
			il.DeclareLocal(typeof(string)).SetLocalSymInfo("input");

			// data = new byte[30000]
			il.Emit(OpCodes.Ldc_I4, 30000);
			il.Emit(OpCodes.Newarr, typeof(byte));
			il.Emit(OpCodes.Stloc_0);
			// dp = 0
			il.Emit(OpCodes.Ldc_I4_0);
			il.Emit(OpCodes.Stloc_1);
			// input = ""
			il.Emit(OpCodes.Ldstr, "");
			il.Emit(OpCodes.Stloc_2);
			// if (args.Length > 0) input = args[0]
			il.Emit(OpCodes.Ldarg_0);
			il.Emit(OpCodes.Ldlen);
			il.Emit(OpCodes.Ldc_I4_0);
			il.Emit(OpCodes.Cgt_Un);
			var noArgsLbl = il.DefineLabel();
			il.Emit(OpCodes.Brfalse_S, noArgsLbl);
			il.Emit(OpCodes.Ldarg_0);
			il.Emit(OpCodes.Ldc_I4_0);
			il.Emit(OpCodes.Ldelem_Ref);
			il.Emit(OpCodes.Stloc_2);
			il.MarkLabel(noArgsLbl);

			_incDec = 0;
			foreach (var c in Code)
			{
				switch (c)
				{
					case '+':
						_incDec++;
						break;
					case '-':
						_incDec--;
						break;
					case '>':
					case '<':
						EmitIncDec(il);
						EmitLeftRight(il, c == '>');
						break;
					case '.':
						EmitIncDec(il);
						EmitOutput(il, writeMethod);
						break;
					case ',':
						EmitIncDec(il);
						EmitInput(il, strLenMethod, strCharsMethod, substringMethod);
						break;
					case '[':
						EmitIncDec(il);
						il.Emit(OpCodes.Ldloc_0);
						il.Emit(OpCodes.Ldloc_1);
						il.Emit(OpCodes.Ldelem_U1);
						il.Emit(OpCodes.Ldc_I4_0);
						il.Emit(OpCodes.Ceq);
						var openLbl = il.DefineLabel();
						var closeLbl = il.DefineLabel();
						OpenLabels.Push(openLbl);
						CloseLabels.Push(closeLbl);
						il.Emit(OpCodes.Brtrue, closeLbl);
						il.MarkLabel(openLbl);
						break;
					case ']':
						EmitIncDec(il);
						il.Emit(OpCodes.Ldloc_0);
						il.Emit(OpCodes.Ldloc_1);
						il.Emit(OpCodes.Ldelem_U1);
						il.Emit(OpCodes.Ldc_I4_0);
						il.Emit(OpCodes.Ceq);
						il.Emit(OpCodes.Brfalse, OpenLabels.Pop());
						il.MarkLabel(CloseLabels.Pop());
						break;
				}
			}

			il.EmitCall(OpCodes.Call, writeLineMethod, null);
			il.Emit(OpCodes.Ret);
			assemblyBuilder.SetEntryPoint(main);
			typeBuilder.CreateType();
			assemblyBuilder.Save(name + ".exe");
			MessageBox.Show("Done");
		}

		private void EmitLeftRight(ILGenerator il, bool right)
		{
			il.Emit(OpCodes.Ldloc_1);
			il.Emit(OpCodes.Ldc_I4_1);
			il.Emit(right ? OpCodes.Add : OpCodes.Sub);
			il.Emit(OpCodes.Stloc_1);
		}

		private void EmitIncDec(ILGenerator il)
		{
			if (_incDec != 0)
			{
				il.Emit(OpCodes.Ldloc_0);
				il.Emit(OpCodes.Ldloc_1);
				il.Emit(OpCodes.Ldloc_0);
				il.Emit(OpCodes.Ldloc_1);
				il.Emit(OpCodes.Ldelem_U1);
				il.Emit(OpCodes.Ldc_I4, _incDec);
				il.Emit(OpCodes.Add);
				il.Emit(OpCodes.Conv_U1);
				il.Emit(OpCodes.Stelem_I1);
			}
			_incDec = 0;
		}

		private void EmitOutput(ILGenerator il, MethodInfo write)
		{
			il.Emit(OpCodes.Ldloc_0);
			il.Emit(OpCodes.Ldloc_1);
			il.Emit(OpCodes.Ldelem_U1);
			il.EmitCall(OpCodes.Call, write, null);
		}

		private void EmitInput(ILGenerator il, MethodInfo strLen, MethodInfo strChars, MethodInfo substring)
		{
			il.Emit(OpCodes.Ldloc_2);
			il.EmitCall(OpCodes.Callvirt, strLen, null);
			il.Emit(OpCodes.Ldc_I4_0);
			il.Emit(OpCodes.Cgt);
			var lbl = il.DefineLabel();
			il.Emit(OpCodes.Brfalse_S, lbl);
			il.Emit(OpCodes.Ldloc_0);
			il.Emit(OpCodes.Ldloc_1);
			il.Emit(OpCodes.Ldloc_2);
			il.Emit(OpCodes.Ldc_I4_0);
			il.EmitCall(OpCodes.Callvirt, strChars, null);
			il.Emit(OpCodes.Conv_U1);
			il.Emit(OpCodes.Stelem_I1);
			il.Emit(OpCodes.Ldloc_2);
			il.Emit(OpCodes.Ldc_I4_1);
			il.EmitCall(OpCodes.Callvirt, substring, null);
			il.Emit(OpCodes.Stloc_2);
			il.MarkLabel(lbl);
		}
	}
}
