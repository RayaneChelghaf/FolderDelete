namespace FolderDelete
{
    public class FolderDeleteService
    {
        static void DeleteOldFolders(string directory, int days)
        {
            DateTime thresholdDate = DateTime.Now.AddDays(-days);

            DirectoryInfo dirInfo = new DirectoryInfo(directory);
            int deletedFoldersCount = 0; // Compteur pour suivre le nombre de suppressions

            foreach (var folder in dirInfo.GetDirectories())
            {
                if (folder.CreationTime < thresholdDate)
                {

                    Console.WriteLine($"Suppression du dossier: {folder.FullName}");
                    folder.Delete(true);  // true pour delete tout le contenu
                    deletedFoldersCount++; // Incrémenter si suppression effectuée
                }
            }

            // Si aucun dossier n'a été supprimé
            if (deletedFoldersCount == 0)
            {
                Console.WriteLine("Aucun dossier à supprimer pour cette période.");
            }
        }

        public static int Main(string[] args)
        {
            if (args.Length < 2)
            {
                Console.WriteLine("Utilisation: dotnet run <baseDir> <days>");
                return 1;
            }

            string baseDir = args[0]; // Premier argument: directory de base
            int days = int.Parse(args[1]); // Second argument: nombre de jours

            if (days <= 0)
            {
                Console.WriteLine("Erreur: Le nombre de jours doit être supérieur à 0.");
                return 1;
            }

            DeleteOldFolders(baseDir, days);

            return 0;
        }
    }

}
