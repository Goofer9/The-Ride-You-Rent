using musicmanagerVCMD12.TableHandler;
using musicmanagerVCMD12.BlobHandler;
using musicmanagerVCMD12.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace musicmanagerVCMD12.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index(string id)
        {
            //for the edit
            if (!string.IsNullOrEmpty(id))
            {
                //set the name of the table for table storage
                TableManager TableManagerObj = new TableManager("musician");

                //retrieve the musician object that matches the row key
                List<Musician> MusicianListObj = TableManagerObj.RetrieveEntity<Musician>("RowKey eq '" + id + "'");
                Musician MusicianObj = MusicianListObj.FirstOrDefault();
                return View(MusicianObj);
            }
            return View(new Musician());
        }

        //for Insert Musician
        [HttpPost]
        public ActionResult Index(string id, HttpPostedFileBase uploadFile, FormCollection formData)
        {
            Musician MusicianObj = new Musician();
            MusicianObj.MusicianName = formData["MusicianName"] == "" ? null : formData["MusicianName"];
            MusicianObj.Genre = formData["Genre"] == "" ? null : formData["Genre"];
            double BookingFee;
            if (double.TryParse(formData["BookingFee"], out BookingFee))
            {
                MusicianObj.BookingFee = double.Parse(formData["BOokingFee"] == "" ? null : formData["BookingFee"]);
            }
            else
            {
                return View(new Musician());
            }

            //upload the profile picture to get the URI
            foreach (string file in Request.Files)
            {
                uploadFile = Request.Files[file];
            }

            //create the blob container
            BlobManager BlobManagerObj = new BlobManager("profilepictures");
            string fileAbsoluteUri = BlobManagerObj.UploadFile(uploadFile);

            MusicianObj.FilePath = fileAbsoluteUri.ToString();

            //Insert into table
            if (string.IsNullOrEmpty(id))
            {
                MusicianObj.PartitionKey = MusicianObj.Genre;
                MusicianObj.RowKey = Guid.NewGuid().ToString();

                TableManager TableManagerObj = new TableManager("musician");
                TableManagerObj.InsertEntity<Musician>(MusicianObj, true);
            }
            //update
            else
            {
                MusicianObj.PartitionKey = MusicianObj.Genre;
                MusicianObj.RowKey = id;

                TableManager TableManagerObj = new TableManager("musician");
                TableManagerObj.InsertEntity<Musician>(MusicianObj, false);
            }
            return RedirectToAction("Get");
        }

        //get Musicians list
        public ActionResult Get()
        {
            TableManager TableManagerObj = new TableManager("musician");

            //retrieve the musician object that matches the row key
            List<Musician> MusicianListObj = TableManagerObj.RetrieveEntity<Musician>(null);
            return View(MusicianListObj);
        }

        //delete musician
        public ActionResult Delete(string id)
        {
            //retrieve musician to be deleted
            TableManager TableManagerObj = new TableManager("musician");

            //retrieve the musician object that matches the row key
            List<Musician> MusicianListObj = TableManagerObj.RetrieveEntity<Musician>("RowKey eq '" + id + "'");
            Musician MusicianObj = MusicianListObj.FirstOrDefault();

            //delete the musican
            TableManagerObj.DeleteEntity<Musician>(MusicianObj);
            return RedirectToAction("Get");
        }
    }
}