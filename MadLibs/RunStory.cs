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
            const string ucic_event = "SheTech"; 
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
                string pronouns = Ask("what are your pronouns? Use she,her format \t");
                string[] pro = pronouns.Split(',');
                while (pro.Length < 2)
                {
                    Console.WriteLine("\nOops! Trouble reading, please try again!");
                    pronouns = Ask("what are your pronouns? Use she,her format \t");
                    pro = pronouns.Split(',');
                }

                they = pro[0];
                them = pro[1]; 

                nouns = Read_From_Queue("noun", 2);
                adjectives = Read_From_Queue("adjective", 2);
                verbs = Read_From_Queue("verb", 2);
            }

            private IEnumerable<string> InterchangeStories()
            {
                string text_file_all = File.ReadAllText("../../../all_stories.txt");
                string[] all_stories = text_file_all.Split("***");
                int size = all_stories.Length; 

                //int count = 1;
                for (int count = 0; count != -1; count++)
                {
                    string story_to_fill = all_stories[count % size];
                    string[] story_words = story_to_fill.Split("#");
                    string full_story = ""; 

                    foreach (string current_word in story_words)
                    {
                        switch (current_word)
                        {
                            case "NAME": 
                                full_story += name;
                                break;
                            case "FRIEND": 
                                full_story += friend;
                                break;
                            case "THEY":
                                full_story += they;
                                break;
                            case "THEM":
                                full_story += them;
                                break;
                            case "EVENT":
                                full_story += ucic_event;
                                break;
                            case "NOUN":
                                full_story += nouns.Dequeue(); 
                                break;
                            case "ADJECTIVE":
                                full_story += adjectives.Dequeue();
                                break;
                            case "VERB":
                                full_story += verbs.Dequeue();
                                break;
                            default:
                                full_story += current_word;
                                break; 

                        }
                    }


                    yield return full_story; 
                }
            }


            public void  Tell()
            {
                IEnumerable<string> all_stories = InterchangeStories(); 
                AskQuestions();
                foreach (string story in all_stories)
                {
                    Console.Write("Producing Story..."); 
                    Thread.Sleep(1000);
                    Console.WriteLine("\n" + story);
                    //wait 10 seconds? 
                    Thread.Sleep(5000);
                    Console.WriteLine("\n\n\n\n\n\n\n Do our madlib! \n\n Answer these questions \n\n\n");
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