using _07_RepositoryPattern_Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _09_StreamingContent_Console
{
    public class ProgramUI
    {
        private readonly StreamingContentRepository _streamingRepo = new StreamingContentRepository();
        public void Run()
        {
            SeedContentList();
            RunMenu();
        }
        private void RunMenu()
        {
            bool continueToRun = true;
            while (continueToRun)
            {
                Console.Clear();
                Console.WriteLine("1) Show all streaming content \n" +
                    "2) Find streaming content by title \n" +
                    "3) Add new streaming content \n" +
                    "4) Remove streaming content \n" +
                    "5) Exit \n");
                Console.Write("Enter the number of the option you would like to select: ");
                String userInput = Console.ReadLine();
                switch (userInput)
                {
                    case "1": //Show All
                        {
                            ShowAll();
                            break;
                        }
                    case "2": //Show by Title
                        {
                            ShowByTitle();
                            break;
                        }
                    case "3":  //Add New Content
                        {
                            CreateNewContent();
                            break;
                        }
                    case "4": //Delete Content
                        {
                            RemoveContent();
                            break;
                        }
                    case "5": //Exit
                        {
                            continueToRun = false;
                            break;
                        }
                    default:
                        {
                            break;
                        }
                }
            }
        }
        private void CreateNewContent()
        {
            Console.Clear();
            StreamingContent content = new StreamingContent();
            /*
            public string Title { get; set; }
            public int RunTimeInMin { get; set; }
            public DateTime ReleaseDate { get; set; }
            public GenreType TypeOfGenre { get; set; }
            public bool IsFamilyFriendly { get; set; }
            */
            Console.Write("Please enter a title: ");
            content.Title = Console.ReadLine();
            Console.WriteLine();
            Console.Write("Please enter the runtime in minutes: ");
            content.RunTimeInMin = int.Parse(Console.ReadLine());
            Console.WriteLine();
            Console.WriteLine(
                "1) Horror \n" +
                "2) Scifi \n" +
                "3) Bromance \n" +
                "4) Action \n" +
                "5) Fantasy \n" +
                "6) Comedy \n" +
                "7) Drama \n" +
                "8) Crime");
            Console.Write("Select a Genre: ");
            string genreChoice = Console.ReadLine();
            int genreID = int.Parse(genreChoice);
            content.TypeOfGenre = (GenreType)genreID;
            Console.WriteLine();
            Console.Write("Is this content family friendly? (Enter True or False): ");
            var fbool = Console.ReadLine().ToLower();
            switch (fbool)
            {
                case "true":
                    {
                        content.IsFamilyFriendly = true;
                        break;
                    }
                case "false":
                    {
                        content.IsFamilyFriendly = false;
                        break;
                    }
            }
            Console.WriteLine();
            Console.Write("What is the release date of this content? (Use format: YYYY,MM,DD): ");
            string rDate = Console.ReadLine();
            DateTime.Parse(rDate);
            content.ReleaseDate = DateTime.Parse(rDate);
            bool added = _streamingRepo.AddContentToDirectory(content);
            Console.WriteLine();
            if (added)
            {
                Console.Write("Your Content has been added. \n" + "\n Press any key to continue...");
            }
            else
            {
                Console.Write("There has been an error, please try again. \n" + " \n Presse any key to continue...");
            }
            Console.ReadKey();
        }
        private void ShowAll()
        {
            Console.Clear();
            List<StreamingContent> listOfContent = _streamingRepo.GetContent();
            foreach (StreamingContent content in listOfContent)
            {
                DisplayContent(content);
            }
            Console.Write("Press any key to continue...");
            Console.ReadKey();
        }
        private void DisplayContent(StreamingContent content)
        {
            Console.WriteLine($"Title: {content.Title} \n" +
                $"Genre: {content.TypeOfGenre} \n" +
                $"This content is family friendly: {content.IsFamilyFriendly} \n" +
                $"Runtime(in min): {content.RunTimeInMin} \n" +
                $"Release Date: {content.ReleaseDate}");
            Console.WriteLine();
        }
        private void ShowByTitle()
        {
            Console.Clear();
            Console.Write("Please enter a title: ");
            string title = Console.ReadLine();
            Console.WriteLine();
            StreamingContent foundContent = _streamingRepo.GetContentByTitle(title);
            if (foundContent != null)
            {
                DisplayContent(foundContent);
            }
            else
            {
                Console.WriteLine("Invalid title. Could not find any results.");
            }
            Console.Write("Press any key to continue.");
            Console.ReadKey();
        }
        private void RemoveContent()
        {
            Console.Clear();
            List<StreamingContent> contentList = _streamingRepo.GetContent();
            int count = 0;
            foreach (StreamingContent content in contentList)
            {
                count++;
                Console.WriteLine($"{count} - {content.Title}");
            }
            Console.WriteLine();
            Console.Write("Which item would you like to remove? (Or enter 0 to go back)...");
            int targetContentId = int.Parse(Console.ReadLine());
            int targetIndex = targetContentId - 1;
            Console.WriteLine();
            if (targetIndex >= 0 && targetIndex < contentList.Count)
            {
                StreamingContent desiredContent = contentList[targetIndex];
                if (_streamingRepo.DeleteExistingContent(desiredContent))
                {
                    Console.WriteLine($"{desiredContent.Title} has been removed");
                }
                else
                {
                    Console.WriteLine("I'm sorry, Dave. I'm afraid I can't do that.");
                }
            }
            if (targetIndex == -1)
            {
                Console.WriteLine("You have not removed any content!");
            }
            else
            {
                Console.WriteLine("No content had that ID.");
            }
            Console.WriteLine();
            Console.Write("Press any key to continue....");
            Console.ReadKey();
        }
        private void SeedContentList()
        {
            StreamingContent aladdin = new StreamingContent("Aladdin", 123, new DateTime(2020, 02, 01), GenreType.Crime, true);
            _streamingRepo.AddContentToDirectory(aladdin);
            StreamingContent jack = new StreamingContent("Jack", 45, new DateTime(1345, 05, 05), GenreType.Fantasy, false);
            _streamingRepo.AddContentToDirectory(jack);
            StreamingContent bigHeroSix = new StreamingContent("Big Hero Six", 236, new DateTime(1934, 02, 02), GenreType.Bromance, true);
            _streamingRepo.AddContentToDirectory(bigHeroSix);
            StreamingContent pB = new StreamingContent("Princess Bride", 9285, new DateTime(1209, 03, 03), GenreType.Action, true);
            _streamingRepo.AddContentToDirectory(pB);
        }
    }
}
