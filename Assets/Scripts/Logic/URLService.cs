using System.Collections.Generic;
using Data;

namespace Logic
{
    public class URLService
    {
        private readonly GalleryData _data;

        public URLService(GalleryData data)
        {
            _data = data;
        }

        public Dictionary<ImageCellView, string> SetURl(List<ImageCellView> imageCells)
        {
            var cellsUrls = new Dictionary<ImageCellView, string>();
        
            for (int i = 0; i < imageCells.Count; i++) 
                cellsUrls.Add(imageCells[i], _data.GalleryURL + $"{i + 1}.jpg");

            return cellsUrls;
        }
    }
}