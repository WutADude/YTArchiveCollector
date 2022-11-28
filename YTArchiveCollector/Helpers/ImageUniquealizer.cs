using ImageProcessor;
using ImageProcessor.Imaging;
using ImageProcessor.Imaging.Filters.Photo;

namespace YTArchiveCollector.Helpers
{
    internal static class ImageUniquealizer
    {
        internal static void UniquealizePreviewAndSave(byte[] ImageBytes)
        {
            using (var InMemStream = new MemoryStream(ImageBytes))
                using (var OutMemStream = new MemoryStream())
                    using (var IFactory = new ImageFactory(preserveExifData:false))
                    {
                        IFactory.Load(InMemStream).Contrast(AnyHelpers.GetTotalyRandomNumber(10, 45)).
                        Filter(MatrixFilters.LoSatch).
                        GaussianBlur(new GaussianLayer().Size = AnyHelpers.GetTotalyRandomNumber(0,2)).
                        Saturation(AnyHelpers.GetTotalyRandomNumber(10, 25)).
                        Vignette(AnyHelpers.GetRandomColor).
                        Save($"{FileManager._SaveFolder}\\Preview\\Preview.jpg");
                    }
        }
    }
}
