using System.Collections.Generic;
using Data;
using UI;

namespace Services
{
    public class URLService
    {
        private readonly GalleryData _data;

        public URLService(GalleryData data)
        {
            _data = data;
        }

        public Dictionary<CellView, string> SetURl(List<CellView> imageCells)
        {
            var cellsUrls = new Dictionary<CellView, string>();
        
            for (int i = 0; i < imageCells.Count; i++) 
                cellsUrls.Add(imageCells[i], _data.GalleryURL + $"{i + 1}.jpg");

            return cellsUrls;
        }
    }
}