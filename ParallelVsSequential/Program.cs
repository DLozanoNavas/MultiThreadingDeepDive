using System.Diagnostics;
using System.Drawing;

static class Program
{
    static void Main(string[] args)
    {
        var originalFilesPath = Path.Join(Directory.GetCurrentDirectory(), "pictures");
        var modifiedFilesPath = Path.Join(Directory.GetCurrentDirectory(), "alteredPictures");
        Directory.CreateDirectory(originalFilesPath);
        Directory.CreateDirectory(modifiedFilesPath);

        var files = Directory.GetFiles(originalFilesPath, "*.jpg", SearchOption.AllDirectories);
        
        ParallelExecution(files, modifiedFilesPath);

        NormalExecution(files, modifiedFilesPath);

    }

    static void ParallelExecution(string[] files, string modifiedFilesPath)
    {
        Stopwatch stopWatch = new();
        stopWatch.Start();
        Parallel.ForEach(files, file =>
        {
            var fileName = Path.GetFileName(file);
            var newFileName = Path.Join(modifiedFilesPath, fileName);
            using var fileBitMap = new Bitmap(file);
            fileBitMap.RotateFlip(RotateFlipType.Rotate180FlipNone);
            fileBitMap.Save(newFileName);
        });
        
        stopWatch.Stop();
        Console.WriteLine("Parallel.ForEach took: " + stopWatch.ElapsedMilliseconds + "ms");
    }

    static void NormalExecution(string[] files, string modifiedFilesPath)
    {
        Stopwatch stopWatch = new();
        stopWatch.Start();
        foreach (var file in files)
        {
            var fileName = Path.GetFileName(file);
            var newFileName = Path.Join(modifiedFilesPath, fileName);
            using var fileBitMap = new Bitmap(file);
            fileBitMap.RotateFlip(RotateFlipType.Rotate180FlipNone);
            fileBitMap.Save(newFileName);
        }
        stopWatch.Stop();
        Console.WriteLine("Normal execution took: " + stopWatch.ElapsedMilliseconds + "ms");
    }
}