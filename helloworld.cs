using System;

namespace helloworld
{
	public class helloworld
	{
		private static readonly string[] HappyEmojis = { "😀", "🎉", "😊", "🥳", "😎", "👏", "✨", "🌟", "💪", "🎊" };
		private static readonly string[] SadEmojis = { "😢", "😭", "😞", "😔", "💔", "😿", "🥺", "☹️", "🙁", "😤" };

		private static readonly Random random = new Random();

		static string GetRandomHappyEmoji()
		{
			return HappyEmojis[random.Next(HappyEmojis.Length)];
		}

		static string GetRandomSadEmoji()
		{
			return SadEmojis[random.Next(SadEmojis.Length)];
		}

		static void Main(string[] args)
		{
			Console.WriteLine("=== 简单数学测试 ===");
			Console.WriteLine("输入 'q' 退出程序");
			Console.WriteLine();

			while (true)
			{
				int num1 = random.Next(1, 100);
				int num2 = random.Next(1, 100);
				int operation = random.Next(4);
				string opSymbol = "";
				double correctAnswer = 0;

				switch (operation)
				{
					case 0:
						opSymbol = "+";
						correctAnswer = num1 + num2;
						break;
					case 1:
						if (num2 > num1)
						{
							int temp = num1;
							num1 = num2;
							num2 = temp;
						}
						opSymbol = "-";
						correctAnswer = num1 - num2;
						break;
					case 2:
						opSymbol = "×";
						correctAnswer = num1 * num2;
						break;
					case 3:
						num2 = random.Next(1, 10);
						num1 = num2 * random.Next(1, 10);
						opSymbol = "÷";
						correctAnswer = num1 / num2;
						break;
				}

				Console.Write($"请计算: {num1} {opSymbol} {num2} = ");
				string input = Console.ReadLine();

				if (input?.ToLower() == "q")
				{
					Console.WriteLine("再见！");
					break;
				}

				if (double.TryParse(input, out double userAnswer))
				{
					if (Math.Abs(userAnswer - correctAnswer) < 0.001)
					{
						Console.WriteLine($"正确！{GetRandomHappyEmoji()}");
					}
					else
					{
						Console.WriteLine($"错误！正确答案是 {correctAnswer} {GetRandomSadEmoji()}");
					}
				}
				else
				{
					Console.WriteLine($"请输入有效数字！{GetRandomSadEmoji()}");
				}
				Console.WriteLine();
			}
		}
	}
}
