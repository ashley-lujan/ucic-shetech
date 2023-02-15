using System.Security.Cryptography.X509Certificates;

namespace MadLibs
{
    internal class RunStory
    {
        public static IEnumerable<string> InterchangeStories()
        {
            List<string> all_stories = new List<string>()
            {
                "1", "2", "3", "4", "5"
            };

            for (int i = 0; i < all_stories.Count; i++)
            {
                Console.WriteLine(all_stories[i]);
                yield return all_stories[i];
                if (i == all_stories.Count - 1) { i = -1; }

            }
        }


        public class Story
        {
            string name;
            string friend;
            string they;
            string them;
            Queue<string> nouns;
            Queue<string> adjectives;
            Queue<string> verbs;

            //List<string> all_stories; 

            //TODO; change a lot of the things to static and make sure you pass in a string
            public Story()
            {
                AskQuestions(); 

            }

            private string Ask(string question)
            {
                Console.Write(question);
                return Console.ReadLine();
            }

            private Queue<string> Read_From_Queue(string section, int quantities)
            {
                Queue<string> section_queue = new Queue<string>();

                for (int i = 0; i < quantities; i++)
                {
                    Console.WriteLine("Please enter a(n) " + section + "\t");
                    section_queue.Enqueue(Console.ReadLine());
                }
                return section_queue;
            }

            private void AskQuestions()
            {
                name = Ask("What is your name\t");
                friend = Ask("What is a friend's name\t");
                string pronouns = Ask("what are your pronouns? Use she/her format \t");
                string[] pro = pronouns.Split("/");
                while (pro.Length < 2)
                {
                    Console.WriteLine("\nOops! Trouble reading, please try again!");
                    pronouns = Ask("what are your pronouns? Use she,her format \t");
                    pro = pronouns.Split(",");
                }

                they = pro[0];
                them = pro[1]; 

                they = "she";
                them = "her";
                nouns = Read_From_Queue("noun", 2);
                adjectives = Read_From_Queue("adjective", 2);
                verbs = Read_From_Queue("verb", 2);
            }

            private IEnumerable<string> InterchangeStories()
            {
                
                //int count = 1;
                int num_of_stories = 3;
                for (int count = 0; count != -1; count++)
                {
                    if(count % num_of_stories == 0)
                    {
                        yield return $"Today {name} is at the major expo {they} hopes to {adjectives.Dequeue()} with {friend}. {nouns.Dequeue()} at today's conference {verbs.Dequeue()} to {nouns.Dequeue()} which is {adjectives.Dequeue()} the best. "; 
                    }
                    else if (count % num_of_stories == 1)
                    {
                        yield return $"Hi {name} and {friend}! We are glad you made it to major expo this year and stopped by our booth! Don't forget to pick up a {nouns.Dequeue()} while you {verbs.Dequeue()} around today. If you happen to find a {adjectives.Dequeue()} {nouns.Dequeue()} be sure to take a selfie with it. Go have a {adjectives.Dequeue()} day!"; 
                    }
                    else if (count % num_of_stories == 2)
                    {
                        yield return $"Yesterday, {name} went to the store with {friend}! They bought a {adjectives.Dequeue()} {nouns.Dequeue()} and forgot they had to go {verbs.Dequeue()} with their {adjectives.Dequeue()} {nouns.Dequeue()}.";
                    }

                }
            }


            public void  Tell()
            {
                IEnumerable<string> all_stories = InterchangeStories(); 
                foreach (string story in all_stories)
                {
                    Console.WriteLine("\n" + story);
                    //wait 10 seconds? 
                    Thread.Sleep(1000);
                    Console.WriteLine("\n\n\n\n\n\n\n Do our madlib! \n\n\n\n\n"); 
                    AskQuestions(); 
                }

            }
        }


        static void Main(string[] args)
        {
            Story story = new Story(); 
            story.Tell();
        }
    }
}