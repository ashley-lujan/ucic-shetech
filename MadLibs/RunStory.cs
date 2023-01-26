namespace MadLibs
{
    internal class RunStory
    {

        public class Story
        {
            string name;
            string friend;
            string they;
            string them; 
            Queue<string> nouns; 
            Queue<string> adjectives; 
            Queue<string> verbs; 

            public Story()
            {
                name = Ask("What is your name");
                friend = Ask("What is a friend's name");
                nouns = Read_From_Queue("noun", 3); 
                adjectives = Read_From_Queue("adjective", 4); 
                verbs = Read_From_Queue("verb", 3); 
            }

            private string Ask(string question)
            {
                Console.Write(question);
                return Console.ReadLine(); 
            }

            private Queue<string> Read_From_Queue(string section, int quantities)
            {
                Queue<string> section_queue = new Queue<string>();
                
                for(int i = 0; i < quantities; i++) 
                {
                    Console.WriteLine("Please enter a(n) " + section); 
                    section_queue.Enqueue(Console.ReadLine());  
                }
                return section_queue;
            }
        }
        

        static void Main(string[] args)
        {
            Console.WriteLine("Hello, World!");
            Story story = new Story();
        }
    }
}