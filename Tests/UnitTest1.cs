using FolderDelete;

namespace Tests
{
    public class Test
    {
        static void ChangeFolderModificationDate(string folderPath, DateTime newDate)
        {
            var dirInfo = new DirectoryInfo(folderPath);

            dirInfo.CreationTime = newDate;
            dirInfo.LastAccessTime = newDate;
            dirInfo.LastWriteTime = newDate;

            Console.WriteLine($"Modification de la date de création de {folderPath} à {newDate}");
        }

        [Fact]
        public void TestBadArgument()
        {
            var exitCode = FolderDeleteService.Main(new[] { "" });

            Assert.NotEqual(0, exitCode);
        }



        [Fact]
        public void TestDeleteFile()
        {
            // AAA

            // Arrange 

            var testFolder = new DirectoryInfo("_testData");

            if (testFolder.Exists)
            {
                testFolder.Delete(true);
            }

            testFolder.Create();


            var directoryOld = new DirectoryInfo(Path.Combine(testFolder.FullName, "old.folder"));
            var directoryNew = new DirectoryInfo(Path.Combine(testFolder.FullName, "new.folder"));

            directoryOld.Create();
            directoryNew.Create();

            var limitDay = 10;


            var dateOld = DateTime.Now.AddDays(-50);
            var dateNew = DateTime.Now.AddDays(-5);

            var limit = DateTime.Now.AddDays(-limitDay);

            ChangeFolderModificationDate(directoryOld.FullName, dateOld);
            ChangeFolderModificationDate(directoryNew.FullName, dateNew);

            // Act 

            var exitCode = FolderDeleteService.Main(new[] { testFolder.FullName, limitDay.ToString() });
            var files = testFolder.EnumerateDirectories("*.folder").ToList();


            // Assert

            Assert.Equal(0, exitCode);
            Assert.Single(files);
            Assert.Equal(directoryNew.Name, files.First().Name);
        }
    }

}