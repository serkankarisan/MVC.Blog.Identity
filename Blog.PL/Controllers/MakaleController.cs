using Blog.BLL.Repository;
using Blog.DAL.Context;
using Blog.Entity.Entity;
using Blog.Entity.ViewModel;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Blog.PL.Controllers
{
    [Authorize]
    public class MakaleController : BaseController
    {
        Repository<Article> repoM = new Repository<Article>(new BlogContext());
        Repository<Comment> repoC = new Repository<Comment>(new BlogContext());
        Repository<Category> repoCat = new Repository<Category>(new BlogContext());
        public ActionResult Index()
        {
            return View(repoM.GetAll(null, m => m.OrderByDescending(x => x.CreatedDate)).Take(4));
        }
        //[Authorize(Roles = "Admin, Yazar")]
        [Authorize]
        public ActionResult Ekle()
        {
            return View();
        }
        [HttpPost, ValidateInput(false)]
        public ActionResult Ekle(MakaleAddViewModel model)
        {
            if(model.PictureUpload != null)
            {
                string filename = model.PictureUpload.FileName;
                string imagePath = Server.MapPath("/images/" + filename);
                model.PictureUpload.SaveAs(imagePath);
                Article yeni = new Article();
                yeni.Title = model.Title;
                yeni.Summary = model.Summary;
                yeni.Content = model.Content;
                yeni.Picture = filename;
                yeni.CategoryId = model.CategoryId;
                yeni.UserId = HttpContext.User.Identity.GetUserId();
                if (repoM.Add(yeni))
                    return RedirectToAction("Index");
                return View(model);
            }
            return View();
        }
        public ActionResult MakaleDetay(int Id)
        {
            MakaleDetayViewModel mdvm = new MakaleDetayViewModel();
            mdvm.Makale = repoM.GetById(Id);
            mdvm.Yorum = new Comment();
            mdvm.Yorumlar = mdvm.Makale.Comments.ToList();
            return View(mdvm);
        }
        [HttpPost]
        public ActionResult MakaleDetay(MakaleDetayViewModel model)
        {
            Comment yeniYorum = new Comment();
            yeniYorum.ArticleId = model.Makale.Id;
            yeniYorum.Content = model.Yorum.Content;
            yeniYorum.UserId = HttpContext.User.Identity.GetUserId();
            if (repoC.Add(yeniYorum))
            {
                return Redirect("/Makale/MakaleDetay/"+model.Makale.Id);
            }

            return View();
        }
        public ActionResult Kategoriler()
        {
            return View(repoCat.GetAll(c=>c.IsDeleted==false));
        }
        public ActionResult KategoriEkle()
        {
            return View();
        }
        [HttpPost]
        public ActionResult KategoriEkle(KategoriViewModel model)
        {
            Category yeniKategori = new Category();
            if (repoCat.GetAll(c => c.Name == model.Name).FirstOrDefault()!= null)
            {
                yeniKategori = repoCat.GetAll(c => c.Name == model.Name).FirstOrDefault();
                if (yeniKategori.IsDeleted == false)
                {
                    ModelState.AddModelError("", "Bu kategori sistemde kayıtlı!");
                    return View(model);
                }
                else
                {
                    yeniKategori.CreatedDate = DateTime.Now;
                    if (string.IsNullOrEmpty(model.Description))
                    {
                        yeniKategori.Description = "Açıklama girilmemiş.";
                    }
                    else
                    {
                        yeniKategori.Description = model.Description;
                    }
                    yeniKategori.Name = model.Name;
                    yeniKategori.IsDeleted = false;
                    if (repoCat.Update(yeniKategori))
                    {
                        return Redirect("/Makale/Kategoriler/");
                    }
                    return View(model);
                }
            }
            yeniKategori.CreatedDate = DateTime.Now;
            if (string.IsNullOrEmpty(model.Description))
            {
                yeniKategori.Description = "Açıklama girilmemiş.";
            }
            else
            {
                yeniKategori.Description = model.Description;
            }
            yeniKategori.Name = model.Name;
            yeniKategori.IsDeleted = false;
            if (repoCat.Add(yeniKategori))
            {
                return Redirect("/Makale/Kategoriler/");
            }

            return View(model);
        }
        public ActionResult KategoriDuzenle(int id)
        {
            KategoriViewModel model = new KategoriViewModel();
            Category kategori=repoCat.GetById(id);
            model.Description = kategori.Description;
            model.Name = kategori.Name;
            model.Id = kategori.Id;
            return View(model);
        }
        [HttpPost]
        public ActionResult KategoriDuzenle(KategoriViewModel model)
        {
            Category yeniKategori = repoCat.GetAll(c => c.Id == model.Id).FirstOrDefault();
            if (yeniKategori == null)
            {
                ModelState.AddModelError("", "Bu kategori sistemde bulunamadı!");
                return Redirect("/Makale/Kategoriler/");
            }
                yeniKategori.CreatedDate = DateTime.Now;
                if (string.IsNullOrEmpty(model.Description))
            {
                yeniKategori.Description = "Açıklama girilmemiş.";
            }
            else
            {
                yeniKategori.Description = model.Description;
            }
            yeniKategori.Name = model.Name;
            yeniKategori.IsDeleted = false;
            if (repoCat.Update(yeniKategori))
            {
                return Redirect("/Makale/Kategoriler/");
            }

            return View(model);
        }
        public ActionResult KategoriSil(int id)
        {
            Category kategori = repoCat.GetById(id);
            kategori.IsDeleted = true;
            repoCat.Delete(kategori);

            return Redirect("/Makale/Kategoriler/");
        }
    }
}