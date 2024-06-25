

namespace ProjectsManager
{
    class Program
    {
        static void Main(string[] args)
        {
            // Check that the data file exists
            var loadedData = new JsonFileHandler("data.json").LoadData();
            if (loadedData != null)
            {
                Console.WriteLine(loadedData.Message);
            }
            // If not found, create a new data file
            else
            {
                Console.WriteLine("No data found.");
                var data = new Data {Projects = new List<Project>()};
                new JsonFileHandler("data.json").SaveData(data);
            }

            while (true)
            {
                Console.WriteLine("Here are the Current Projects:");
                var projects = new JsonFileHandler("data.json").LoadData().Projects;
                if (projects != null)
                {
                    int i = 0;
                    for( i = 0; i < projects.Count; i++)
                    {
                        Console.WriteLine(i + ". " + projects[i].Name + " - " + projects[i].Status);
                    }
                    Console.WriteLine(i + ". Add a new project");   
                    Console.WriteLine(i + 1 + ". Remove a project");
                    Console.WriteLine(i + 2 + ". Edit a project");
                    Console.WriteLine(i + 3 + ". Exit");
                    
                    var choice = Console.ReadLine();
                    if (int.TryParse(choice, out int index))
                    {
                        if (index == i)
                        {
                            Console.WriteLine("Enter the name of the project:");
                            var name = Console.ReadLine();
                            Console.WriteLine("Enter the git url of the project:");
                            var gitUrl = Console.ReadLine();
                            Console.WriteLine("Enter the software open of the project:");
                            var softwareOpen = Console.ReadLine();
                            Console.WriteLine("Enter the path of the project:");
                            var path = Console.ReadLine();
                            Console.WriteLine("Enter the status of the project:");
                            var status = Console.ReadLine();
                            projects.Add(new Project
                            {
                                Name = name,
                                GitUrl = gitUrl,
                                SoftwareOpen = softwareOpen,
                                Path = path,
                                Status = status
                            });
                            new JsonFileHandler("data.json").SaveData(new Data {Projects = projects});
                        }
                        else if (index == i + 1)
                        {
                            Console.WriteLine("Enter the index of the project to remove:");
                            var indexToRemove = Console.ReadLine();
                            if (int.TryParse(indexToRemove, out int indexToRemoveInt))
                            {
                                projects.RemoveAt(indexToRemoveInt);
                                new JsonFileHandler("data.json").SaveData(new Data {Projects = projects});
                            }
                        }
                        else if (index == i + 2)
                        {
                            Console.WriteLine("Enter the index of the project to edit:");
                            var indexToEdit = Console.ReadLine();
                            if (int.TryParse(indexToEdit, out int indexToEditInt))
                            {
                                Console.WriteLine("Leave blank to keep the same value.");
                                Console.WriteLine("Enter the name of the project:");
                                var name = Console.ReadLine();
                                if(name == "") 
                                {
                                    name = projects[indexToEditInt].Name;
                                }
                                Console.WriteLine("Enter the git url of the project:");
                                var gitUrl = Console.ReadLine();
                                if(gitUrl == "") 
                                {
                                    gitUrl = projects[indexToEditInt].GitUrl;
                                }
                                Console.WriteLine("Enter the software open of the project:");
                                var softwareOpen = Console.ReadLine();
                                if(softwareOpen == "") 
                                {
                                    softwareOpen = projects[indexToEditInt].SoftwareOpen;
                                }
                                Console.WriteLine("Enter the path of the project:");
                                var path = Console.ReadLine();
                                if(path == "")
                                {
                                    path = projects[indexToEditInt].Path;
                                }
                                Console.WriteLine("Enter the status of the project:");
                                var status = Console.ReadLine();
                                if(status == "")
                                {
                                    status = projects[indexToEditInt].Status;
                                }
                                projects[indexToEditInt] = new Project
                                {
                                    Name = name,
                                    GitUrl = gitUrl,
                                    SoftwareOpen = softwareOpen,
                                    Path = path,
                                    Status = status
                                };
                                new JsonFileHandler("data.json").SaveData(new Data {Projects = projects});
                            }
                        } else if (index == i + 3)
                        {
                            break;
                        }
                        else
                        {
                            // This means it is a Project or null
                            if (index >= 0 && index < projects.Count)
                            {
                                Console.WriteLine("Name: " + projects[index].Name);
                                Console.WriteLine("Git Url: " + projects[index].GitUrl);
                                Console.WriteLine("Software Open: " + projects[index].SoftwareOpen);
                                Console.WriteLine("Path: " + projects[index].Path);
                                Console.WriteLine("Status: " + projects[index].Status + "\n");
                                
                                // Open the project in the Software Open

                                if (projects[index].SoftwareOpen.ToLower() == "vscode")
                                {
                                    OpenIn.VSCode(projects[index].Path);
                                    String data = Console.ReadLine();
                                    break;
                                } else if (projects[index].SoftwareOpen.ToLower() == "intelij")
                                {
                                    OpenIn.IntelliJ(projects[index].Path);
                                    String data = Console.ReadLine();
                                    break;
                                } else
                                {
                                    Console.WriteLine("Invalid Software Open.");
                                }
                            }
                        }
                    }
                    else
                    {
                        Console.WriteLine("Invalid choice.");
                    }
                }
                else
                {
                    break;
                }
            }
            Console.WriteLine("Internal Error!");
        }
    }
}

