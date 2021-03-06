﻿using System;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.IO;

namespace NeuroNetTest
{
	class MainClass
	{
		
		private static int CountOfHiddenNeirons = 3;
		private static int Range = 5;
		private static int CountOfInputsInOneNeuron = 5;
		private static bool IsDebugOn = false;
		private static  bool IsAttackSuccess = false;

		public static void Main (string[] args)
		{


			while (true)
			{
				Console.Write ("-------------------------------------------------------------------------\nWelсome to the first test of passive MITM attack in neural cryptography algorithm.\n Do you want to input start parameters?\n[y/n/q] ");
				char foo = Convert.ToChar (Console.ReadLine ());
				var FirstAtack = new TestEveAtack ();
				switch (foo) {
				case 'n':
					FirstAtack.GetInitData (4, 3, 20, false, ref IsAttackSuccess);
					continue;

				case 'y':
					try {
						Console.Write ("Count Of Inputs In One Neuron: ");
						CountOfInputsInOneNeuron = Convert.ToInt32 (Console.ReadLine ());

						Console.Write ("Count Of Hidden Neirons: ");
						CountOfHiddenNeirons = Convert.ToInt32 (Console.ReadLine ());

						Console.Write ("Range of key values: ");
						Range = Convert.ToInt32 (Console.ReadLine ());

						Console.Write ("Is debug-mod On? [true/fasle]: ");
						string bar = Console.ReadLine ();
						if (bar != "true" && bar != "false")
							throw new Exception ("invalid arg!");
						else if (bar == "true")
							IsDebugOn = Convert.ToBoolean (1);
							else
							IsDebugOn = Convert.ToBoolean (0);
	
						if (Range <= 0 || CountOfHiddenNeirons <= 0 || CountOfInputsInOneNeuron <= 0)
							throw new Exception ("invalid arg!");
						FirstAtack.GetInitData (CountOfInputsInOneNeuron, CountOfHiddenNeirons, Range, IsDebugOn, ref IsAttackSuccess);
					} catch (Exception e) {
						Console.WriteLine (e.Message);
						break;
					}
					continue;

				case 'q':
					return;
				default:
					Console.WriteLine ("error!");
					continue;
				}
					
			}

		}
	}
}