namespace TheLongGame
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Initialize variables
            string username;
            int score = 0;
            bool over = false;

            // Get user's name
            Console.Write("Enter your username: ");
            username = Console.ReadLine();

            // Ensure valid user name (not blank or white space)
            while (string.IsNullOrWhiteSpace(username) || username.Contains(" "))
            {
                Console.Write("Please enter a valid username: ");
                username = Console.ReadLine();
            }

            // Check if file with username already exists
            if ( File.Exists($"{username}.txt") ) 
            {
                Console.WriteLine($"Welcome back, {username}!");

                // Retrieves existing data
                StreamReader reader = new StreamReader($"{username}.txt");
                score = int.Parse(reader.ReadLine());
                reader.Close();
            }
            else
            {
                Console.WriteLine($"Welcome, {username}!");
            }
            Console.WriteLine($"Current score: {score}\n");

            // Gameplay
            while (!over)
            {
                if (Console.ReadKey().Key == ConsoleKey.Enter)
                {
                    // Ends game when player presses Enter
                    over = true;
                } 
                else
                {
                    score++;
                    Console.WriteLine($"\bUpdated score: {score}");
                }
            }
            Console.WriteLine($"\nNew score: {score}");

            // Save score to file
            StreamWriter writer = new StreamWriter($"{username}.txt", false);
            writer.WriteLine(score);
            writer.Close();
        }
    }
}
