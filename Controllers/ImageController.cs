using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web;
using System.IO;
using System.Threading.Tasks;
using System.Diagnostics;
using System.Drawing;
using WebImage.Functions;
using WebImage.Models;

namespace WebImage.Controllers
{
    [RoutePrefix("api/imaging")]
    public class ImageController : ApiController
    {
        [HttpPost]
        [Route("json")]
        public async Task<ImageResponse> PostBase64(ImagePost posted)
        { 
            //create new image handler class
            var iM = new ImageMethods();

            //get upload folder path
            var folderName = "/public/uploads/";
            var path = HttpContext.Current.Server.MapPath(folderName);
            var rootUrl = Request.RequestUri.AbsoluteUri.Replace(Request.RequestUri.AbsolutePath, String.Empty);

            //set image name
            string imageName = posted.Upload_name + "." + posted.Media_format;            

            //set the image path
            string imgPath = Path.Combine(path, imageName);

            byte[] imageBytes = Convert.FromBase64String(posted.Upload_file);
            Image image = (Bitmap)((new ImageConverter()).ConvertFrom(imageBytes));

            //set output object
            ImageResponse response;            

            try
            {
                Image image_out;

                switch (posted.Upload_operation)
                {
                    case "2":
                        image_out = iM.transformImage(image);
                        break;
                    case "1":
                        image_out = iM.textImage(image, posted.Upload_text);
                        break;
                    default:
                        Size size1;
                        if (posted.Res != null)
                        {
                            size1 = new Size( Convert.ToInt32(posted.Res.width), Convert.ToInt32(posted.Res.height));
                        }
                        else
                        {
                            size1 = new Size(400, 400);
                        }

                        image_out = iM.resizeImage(image, size1);
                        break;
                }

                image_out.Save(imgPath); 

                //get file
                var info = new FileInfo(imgPath);
                var fpath = path + info.Name;

                //add to response                   
                response = new ImageResponse(info.Name, imgPath, info.Length / 1024, "");  
            }
            catch (Exception e)
            {
                response = new ImageResponse("failed", path, 0, e.Message); 
            }

            return response;
        }
    }
}
