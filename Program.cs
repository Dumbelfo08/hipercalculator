using System;
using System.Numerics;

class Program
{
		
	static void Main()
	{
		Console.ForegroundColor = ConsoleColor.DarkCyan;
		log("Welcome!");
		bool writeToFile = askYN("Do you want to write the result to a text file");
		int bas;
		int exp;
		int mod;
		while(true){
			Console.ForegroundColor = ConsoleColor.Blue;
			log("");
			bas = askX("What is the base(send 'x' to exit)");
			if(bas == -1){
				break;
			}
			exp = ask("What is the exponent");
			mod = ask("What is the hipermodule");
			
			Console.ForegroundColor = ConsoleColor.White;
			log("Calculating: " + bas + new string('^', mod) + exp);
			
			if(writeToFile){
				File.WriteAllText("result.txt", "The result of " + bas + new string('^', mod) + exp + " is: " + modularPower(bas, exp, mod));
				log("The operation " + bas + new string('^', mod) + exp + " has finished");
			} else {
				log("The result of " + bas + new string('^', mod) + exp + " is: " + modularPower(bas, exp, mod));
			}
		}
	}	


	static BigInteger power(BigInteger bas, BigInteger exp){
		if (exp == 0){
			return 1;
		}
		
		BigInteger res = bas;
		
		for (int i = 1; i < exp;i++){
			res = res * bas;
		}
		return res;
	}
	
	static BigInteger modularPower(BigInteger bas, BigInteger exp, int module){
		if (module==1){
			return power(bas,exp);
		}
		
		BigInteger res = bas;
		
		for (int i = 1; i < exp;i++){
			res = modularPower(bas,res,module-1);
		}
		
		return res;
	}
	
	static void log (object o){ //im too lazy to write 'Console.WriteLine'
		Console.WriteLine(o.ToString());
	}
	
	static int ask (string question){
		int res;
		string b;
		ConsoleColor prev = Console.ForegroundColor;
		do
		{
			Console.Write(question+"?: ");
			Console.ForegroundColor = ConsoleColor.White;
			b = Console.ReadLine();
			Console.ForegroundColor = prev;
		}
		while (!int.TryParse(b, out res));
		return res;
	}
	
	static int askX (string question){
		int res;
		string b;
		ConsoleColor prev = Console.ForegroundColor;
		do
		{
			Console.Write(question+"?: ");
			Console.ForegroundColor = ConsoleColor.White;
			b = Console.ReadLine();
			Console.ForegroundColor = prev;
			if (b=="x" || b=="X"){
				return -1;
			}
		}
		while (!int.TryParse(b, out res));
		return res;
	}
	
	static bool askYN (string question){
		string b;
		ConsoleColor prev = Console.ForegroundColor;
		do
		{
			Console.Write(question+"?(Y/N): ");
			Console.ForegroundColor = ConsoleColor.White;
			b = Console.ReadLine();
			Console.ForegroundColor = prev;
		}
		while (!(b == "Y" || b == "y" || b == "N" || b == "n"));
		if (b == "Y" || b == "y"){
			return true;
		}
		if (b == "N" || b == "n"){
			return false;
		}
		return false;
	}
}