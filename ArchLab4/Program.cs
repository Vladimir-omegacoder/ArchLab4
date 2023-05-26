


using System.Text;

namespace ArchLab4
{
    internal class Program
    {
        private static int Main(string[] args)
        {
            string? dir_path, dir_name, dir_attr;


            Console.WriteLine("Enter directory path:");
            dir_path = Console.ReadLine();

            Console.WriteLine("Enter directory name\n(TIP. Use '*' to search for all familiar directories):");
            dir_name = Console.ReadLine();

            Console.WriteLine("Enter directory attributes to exclude(optional):\n(TIP. h - hidden, r - readonly, a - archive ready):");
            dir_attr = Console.ReadLine();


            EnumerationOptions options = new EnumerationOptions();

            if (dir_attr.Contains('h'))
            {
                options.AttributesToSkip |= FileAttributes.Hidden;
            }
            if (dir_attr.Contains('r'))
            {
                options.AttributesToSkip |= FileAttributes.ReadOnly;
            }
            if (dir_attr.Contains('a'))
            {
                options.AttributesToSkip |= FileAttributes.Archive;
            }


            string[] dirs = Directory.GetDirectories(dir_path, dir_name, options);

            if (dirs.Length == 0)
            {
                Console.WriteLine("No such directories found.");

                return 1;
            }
            else
            {
                Console.WriteLine("Directories found:");
                foreach (string dir in dirs)
                {
                    Console.WriteLine(dir);
                }

                return 0;
            }

        }

    }

}