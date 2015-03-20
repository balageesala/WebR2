using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using IntellidateR1;
using System.Configuration;
using System.Web;

namespace IntelliWebR1.API
{
    public class GetPhotosController : ApiController
    {
        // GET api/<controller>
        public Photo[] Get()
        {
            int _UserID = Convert.ToInt32(HttpContext.Current.User.Identity.Name);
            Photo[] _UserPhotos = new Photo().GetUserPhotos(_UserID, ConfigurationManager.AppSettings["PhotosFolder"].ToString(), 230, 550);

            foreach (var item in _UserPhotos)
            {
                item.PhotoPath = new Utils().GetPhotoPCGTPath(item.PhotoID, HttpContext.Current.Request);
                item.EncryptPath = new Utils().GetPhotoFullViewPath(item.PhotoID, HttpContext.Current.Request);
            }

            return _UserPhotos;

            /*List<GridColum> _GridColumns = new List<GridColum>();
            for (int i = 0; i < 5; i++)
            {
                _GridColumns.Add(new GridColum { ColumnData = null, ColumnHeight = 0 });
            }

            foreach (Photo EachPhoto in _UserPhotos)
            {
                // Find the smalles gridcolumn
                GridColum _Smallest = GetSmallest(_GridColumns.ToArray());
                AddPhotoInGridColumn(_Smallest, EachPhoto);
            }

            PhotoGrid _PhotoGrid = new PhotoGrid
            {
                GridColums = _GridColumns.ToArray()
            };
            return _PhotoGrid;*/
        }

        private void AddPhotoInGridColumn(GridColum _GridColumn, Photo PhotoToAdd)
        {
            if (_GridColumn.ColumnData == null)
            {
                _GridColumn.ColumnData = new List<Photo>();
            }
            _GridColumn.ColumnData.Add(PhotoToAdd);
            _GridColumn.ColumnHeight = _GridColumn.ColumnHeight + PhotoToAdd.Height + 20;
        }

        private GridColum GetSmallest(GridColum[] AllGridColums)
        {
            
            foreach (var item in AllGridColums)
            {
                if (item.ColumnHeight == 0)
                {
                    return item;
                }
            }

            GridColum _Smallest = AllGridColums.OrderBy(x => x.ColumnHeight).FirstOrDefault();

            return _Smallest;
        }

        // GET api/<controller>/5
        public IEnumerable<Photo> Get(string value)
        {
            try
            {
                int OtherUserID = Convert.ToInt32(new EncryptDecrypt().Decrypt(value));

                Photo[] _UserPhotos = new Photo().GetUserPhotos(OtherUserID, ConfigurationManager.AppSettings["PhotosFolder"].ToString(), 200, 400);
                return _UserPhotos;
            }
            catch (Exception)
            {
                return null;
            }
        }

        // POST api/<controller>
        public Photo[] Post([FromBody]PhotosCommand PhotosCommand)
        {
            try
            {
                if (PhotosCommand.Action == "G")
                {
                    int _UserID = Convert.ToInt32(new EncryptDecrypt().Decrypt(PhotosCommand.UserIDEncrypted));

                    Photo[] _UserPhotos = new Photo().GetUserPhotos(_UserID, ConfigurationManager.AppSettings["PhotosFolder"].ToString(), 230, 550);

                    _UserPhotos = _UserPhotos.OrderBy(x => x.PhotoID).ToArray();
                    if (PhotosCommand.LastShownID > 0)
                    {
                        _UserPhotos = _UserPhotos.Where(x => x.PhotoID > PhotosCommand.LastShownID).Take(20).ToArray();
                    }
                    else
                    {
                        _UserPhotos = _UserPhotos.Take(20).ToArray();
                    }

                    return _UserPhotos;
                }
                if (PhotosCommand.Action == "D")
                {
                    int _UserID = Convert.ToInt32(HttpContext.Current.User.Identity.Name);

                    Photo[] _UserPhotos = new Photo().GetUserPhotos(_UserID, ConfigurationManager.AppSettings["PhotosFolder"].ToString(), 230, 550);

                    _UserPhotos = _UserPhotos.OrderBy(x => x.PhotoID).ToArray();
                    if (PhotosCommand.LastShownID > 0)
                    {
                        _UserPhotos = _UserPhotos.Where(x => x.PhotoID > PhotosCommand.LastShownID).Take(20).ToArray();
                    }
                    else
                    {
                        _UserPhotos = _UserPhotos.Take(20).ToArray();
                    }

                    return _UserPhotos;
                }
                if (PhotosCommand.Action == "GL")
                {
                    int _UserID = Convert.ToInt32(new EncryptDecrypt().Decrypt(PhotosCommand.UserIDEncrypted));

                    Photo[] _UserPhotos = new Photo().GetUserPhotos(_UserID, ConfigurationManager.AppSettings["PhotosFolder"].ToString(), 590, 550);

                    _UserPhotos = _UserPhotos.OrderBy(x => x.PhotoID).ToArray();
                    if (PhotosCommand.LastShownID > 0)
                    {
                        _UserPhotos = _UserPhotos.Where(x => x.PhotoID > PhotosCommand.LastShownID).Take(20).ToArray();
                    }
                    else
                    {
                        _UserPhotos = _UserPhotos.Take(20).ToArray();
                    }

                    return _UserPhotos;
                }
                return null;

            }
            catch (Exception)
            {
                return null;
            }
        }

        // PUT api/<controller>/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/<controller>/5
        public void Delete(int id)
        {
        }
    }

    public class PhotosCommand
    {
        public string UserIDEncrypted { get; set; }
        public int PhotoID { get; set; }
        public string Action { get; set; }
        public int LastShownID { get; set; }
    }

    public class PhotoGrid
    {
        public GridColum[] GridColums { get; set; }
    }

    public class GridColum
    {
        public List<Photo> ColumnData { get; set; }
        public int ColumnHeight { get; set; }
    }
}