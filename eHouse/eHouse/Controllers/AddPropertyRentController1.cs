using eHouse.Models;
using Microsoft.AspNetCore.Mvc;
using System.Dynamic;
using System.Web;
using System.IO;
using System.Collections.Generic;

namespace eHouse.Controllers
{
    public class AddPropertyRentController1 : Controller
    {

        Rentdb DB =new Rentdb();
        private IWebHostEnvironment _IWebHostEnvironment;
        public AddPropertyRentController1(IWebHostEnvironment IWebHostEnvironment)
        {
            _IWebHostEnvironment = IWebHostEnvironment;
        }
        public IActionResult aprent()
        {
            return View();
        }
        [HttpPost]
        [RequestSizeLimit(100_000_000)]
        public IActionResult aprent([Bind] RentModel ar, IFormFile[] imge1)
        
        {

            int Count;
            Count = 0;
            try
            {
                
                if (ModelState.IsValid)
                {
                    if(ar.photos != null && ar.photos.Count>0)
            {
                        string folder = "image/";
                        foreach (IFormFile imge in ar.photos)
                        {
                           
                           
                            Count++;
                            if (Count == 1)
                            {
                                folder += Guid.NewGuid().ToString() + "_" + imge.FileName;




                                ar.pic1 = "/" + folder;

                                string serverFolder = Path.Combine(_IWebHostEnvironment.WebRootPath, folder);
                                imge.CopyTo(new FileStream(serverFolder, FileMode.Create));
                            }
                          
                            if(Count== 2)
                            {
                                folder += Guid.NewGuid().ToString() + "_" + imge.FileName;




                                ar.pic2 = "/" + folder;

                                string serverFolder = Path.Combine(_IWebHostEnvironment.WebRootPath, folder);
                                imge.CopyTo(new FileStream(serverFolder, FileMode.Create));
                            }
                            else if(Count<2)
                            {
                                ar.pic2 = "";
                            }
                            if (Count == 3)
                            {
                                folder += Guid.NewGuid().ToString() + "_" + imge.FileName;




                                ar.pic3 = "/" + folder;

                                string serverFolder = Path.Combine(_IWebHostEnvironment.WebRootPath, folder);
                                imge.CopyTo(new FileStream(serverFolder, FileMode.Create));
                            }
                            else if (Count < 3)
                            {
                                ar.pic3 = "";
                            }
                            if (Count == 4)
                            {
                                folder += Guid.NewGuid().ToString() + "_" + imge.FileName;




                                ar.pic4 = "/" + folder;

                                string serverFolder = Path.Combine(_IWebHostEnvironment.WebRootPath, folder);
                                imge.CopyTo(new FileStream(serverFolder, FileMode.Create));
                            }
                            else if (Count < 4)
                            {
                                ar.pic4 = "";
                            }
                            if (Count == 5)
                            {
                                folder += Guid.NewGuid().ToString() + "_" + imge.FileName;




                                ar.pic5 = "/" + folder;

                                string serverFolder = Path.Combine(_IWebHostEnvironment.WebRootPath, folder);
                                imge.CopyTo(new FileStream(serverFolder, FileMode.Create));
                            }
                            else if(Count < 5)
                            {
                                ar.pic5 = "";
                            }
                            if (Count == 6)
                            {
                                folder += Guid.NewGuid().ToString() + "_" + imge.FileName;




                                ar.pic6 = "/" + folder;

                                string serverFolder = Path.Combine(_IWebHostEnvironment.WebRootPath, folder);
                                imge.CopyTo(new FileStream(serverFolder, FileMode.Create));
                            }
                            else if (Count < 6)
                            {
                                ar.pic6 = "";
                            }
                            if (Count == 7)
                            {
                                folder += Guid.NewGuid().ToString() + "_" + imge.FileName;




                                ar.pic7 = "/" + folder;

                                string serverFolder = Path.Combine(_IWebHostEnvironment.WebRootPath, folder);
                                imge.CopyTo(new FileStream(serverFolder, FileMode.Create));

                            }
                            else if(Count<7)
                            {
                                ar.pic7 = "";
                            }
                            if (Count == 8)
                            {
                                folder += Guid.NewGuid().ToString() + "_" + imge.FileName;




                                ar.pic8 = "/" + folder;

                                string serverFolder = Path.Combine(_IWebHostEnvironment.WebRootPath, folder);
                                imge.CopyTo(new FileStream(serverFolder, FileMode.Create));

                            }
                            else if (Count < 8)
                            {
                                ar.pic8 = "";
                            }
                            if (Count == 9)
                            {
                                folder += Guid.NewGuid().ToString() + "_" + imge.FileName;




                                ar.pic9 = "/" + folder;

                                string serverFolder = Path.Combine(_IWebHostEnvironment.WebRootPath, folder);
                                imge.CopyTo(new FileStream(serverFolder, FileMode.Create));

                            }
                            else if (Count < 9)
                            {
                                ar.pic9 = "";
                            }
                            if (Count == 10)
                            {
                                folder += Guid.NewGuid().ToString() + "_" + imge.FileName;




                                ar.pic10 = "/" + folder;

                                string serverFolder = Path.Combine(_IWebHostEnvironment.WebRootPath, folder);
                                imge.CopyTo(new FileStream(serverFolder, FileMode.Create));

                            }
                            else if (Count < 10)
                            {
                                ar.pic10 = "";
                            }
                        }

                    }
                    //if (ar.imge1 != null)
                    //{
                    //    string folder = "image/";
                    //    folder += Guid.NewGuid().ToString() + "_" + ar.imge1.FileName;

                    //    ar.pic1 = "/" + folder;
                    //    string serverFolder = Path.Combine(_IWebHostEnvironment.WebRootPath, folder);
                    //    ar.imge1.CopyTo(new FileStream(serverFolder, FileMode.Create));

                    //}
                    //if (ar.imge3 != null)
                    //{
                    //    string folder = "image/";
                    //    folder += Guid.NewGuid().ToString() + "_" + ar.imge3.FileName;
                    //    ar.pic3 = "/" + folder;
                    //    string serverFolder = Path.Combine(_IWebHostEnvironment.WebRootPath, folder);
                    //    ar.imge3.CopyTo(new FileStream(serverFolder, FileMode.Create));
                    //}
                    //if (ar.imge4 != null)
                    //{
                    //    string folder = "image/";
                    //    folder += Guid.NewGuid().ToString() + "_" + ar.imge4.FileName;
                    //    ar.pic4 = "/" + folder;
                    //    string serverFolder = Path.Combine(_IWebHostEnvironment.WebRootPath, folder);
                    //    ar.imge4.CopyTo(new FileStream(serverFolder, FileMode.Create));
                    //}
                    //if (ar.imge5 != null)
                    //{
                    //    string folder = "image/";
                    //    folder += Guid.NewGuid().ToString() + "_" + ar.imge5.FileName;
                    //    ar.pic5 = "/" + folder;
                    //    string serverFolder = Path.Combine(_IWebHostEnvironment.WebRootPath, folder);
                    //    ar.imge5.CopyTo(new FileStream(serverFolder, FileMode.Create)); 
                    //}
                    //if (ar.imge6 != null)
                    //{
                    //    string folder = "image/";
                    //    folder += ar.imge6.FileName + Guid.NewGuid().ToString();
                    //    ar.pic6 = "/" + folder;
                    //    string serverFolder = Path.Combine(_IWebHostEnvironment.WebRootPath, folder);
                    //    ar.imge6.CopyToAsync(new FileStream(serverFolder, FileMode.Create));
                    //}
                    //if (ar.imge7 != null)
                    //{
                    //    string folder = "image/";
                    //    folder += ar.imge7.FileName + Guid.NewGuid().ToString();
                    //    ar.pic7 = "/" + folder;
                    //    string serverFolder = Path.Combine(_IWebHostEnvironment.WebRootPath, folder);
                    //    ar.imge7.CopyToAsync(new FileStream(serverFolder, FileMode.Create));

                    //}
                    //if (ar.imge8 != null)
                    //{
                    //    string folder = "image/";
                    //    folder += ar.imge8.FileName + Guid.NewGuid().ToString();
                    //    ar.pic8 = "/" + folder;
                    //    string serverFolder = Path.Combine(_IWebHostEnvironment.WebRootPath, folder);
                    //    ar.imge8.CopyToAsync(new FileStream(serverFolder, FileMode.Create));
                    //}
                    //if (ar.imge9 != null)
                    //{
                    //    string folder = "image/";
                    //    folder += ar.imge9.FileName + Guid.NewGuid().ToString();
                    //    ar.pic9 = "/" + folder;
                    //    string serverFolder = Path.Combine(_IWebHostEnvironment.WebRootPath, folder);
                    //    ar.imge9.CopyToAsync(new FileStream(serverFolder, FileMode.Create));
                    //}
                    //if (ar.imge10 != null)
                    //{
                    //    string folder = "image/";
                    //    folder += ar.imge10.FileName + Guid.NewGuid().ToString();
                    //    ar.pic10 = "/" + folder;
                    //    string serverFolder = Path.Combine(_IWebHostEnvironment.WebRootPath, folder);
                    //    ar.imge10.CopyToAsync(new FileStream(serverFolder, FileMode.Create));
                    //}



                    string res = DB.Saverecord(ar);
                    string pics = DB.imagedb(ar);

                    

                    
                    TempData["msg"] = res;
                }
            }
            catch (Exception ex)
            {
                TempData["msg"] = ex.Message;
            }
            return View();
        }
        public IActionResult addBuilding()
        {
            return View();

        }
        public IActionResult addBanglow()
        {
            return View();

        }
        public IActionResult addIndustrial()
        {
            return View();

        }
        public IActionResult addApartment()
        {
            return View();

        }
        public IActionResult addVillas()
        {
            return View();

        }

    }
}
//string fileName = Path.GetFileNameWithoutExtension(image.imageFile.FileName);
//string extension = Path.GetExtension(image.imageFile.FileName);
//fileName = fileName + DateTime.Now.ToString("yymmssff") + extension;
//image.pic1="~/Content/"+fileName;
//image.pic2 = "~/Content/" + fileName;
//image.pic3 = "~/Content/" + fileName;
//image.pic4 = "~/Content/" + fileName;
//image.pic5 = "~/Content/" + fileName;
//image.pic6 = "~/Content/" + fileName;
//image.pic7 = "~/Content/" + fileName;
//image.pic8 = "~/Content/" + fileName;
//image.pic9 = "~/Content/" + fileName;
//image.pic10 = "~/Content/" + fileName;
//fileName = Path.Combine(HttpContext.Request.Server.MapPath("~/Content/"));
//image.imageFile.SaveAs(fileName);

//ar.imge2.CopyToAsync(new FileStream(serverFolder, FileMode.Create));
//ar.imge3.CopyToAsync(new FileStream(serverFolder, FileMode.Create));
//ar.imge4.CopyToAsync(new FileStream(serverFolder, FileMode.Create));
//ar.imge5.CopyToAsync(new FileStream(serverFolder, FileMode.Create));
//ar.imge6.CopyToAsync(new FileStream(serverFolder, FileMode.Create));
//ar.imge7.CopyToAsync(new FileStream(serverFolder, FileMode.Create));
//ar.imge8.CopyToAsync(new FileStream(serverFolder, FileMode.Create));
//ar.imge9.CopyToAsync(new FileStream(serverFolder, FileMode.Create));
//ar.imge10.CopyToAsync(new FileStream(serverFolder, FileMode.Create));


//folder += ar.imge2.FileName + Guid.NewGuid().ToString();
//folder += ar.imge3.FileName + Guid.NewGuid().ToString();
//folder += ar.imge4.FileName + Guid.NewGuid().ToString();
//folder += ar.imge5.FileName + Guid.NewGuid().ToString();
//folder += ar.imge6.FileName + Guid.NewGuid().ToString();
//folder += ar.imge7.FileName + Guid.NewGuid().ToString();
//folder += ar.imge8.FileName + Guid.NewGuid().ToString();
//folder += ar.imge9.FileName + Guid.NewGuid().ToString();
//folder += ar.imge10.FileName + Guid.NewGuid().ToString();
//ar.pic1 += ar.imge1.FileName + Guid.NewGuid().ToString();
//ar.pic2 += ar.imge2.FileName + Guid.NewGuid().ToString();
//ar.pic3 += ar.imge3.FileName + Guid.NewGuid().ToString();
//ar.pic4 += ar.imge4.FileName + Guid.NewGuid().ToString();
//ar.pic5 += ar.imge5.FileName + Guid.NewGuid().ToString();
//ar.pic6 += ar.imge6.FileName + Guid.NewGuid().ToString();
//ar.pic7 += ar.imge7.FileName + Guid.NewGuid().ToString();
//ar.pic8 += ar.imge8.FileName + Guid.NewGuid().ToString();
//ar.pic9 += ar.imge9.FileName + Guid.NewGuid().ToString();
//ar.pic10 += ar.imge10.FileName + Guid.NewGuid().ToString();