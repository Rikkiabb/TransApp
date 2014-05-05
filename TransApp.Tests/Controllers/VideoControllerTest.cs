﻿using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TransApp.Models;
using System.Collections.Generic;
using TransApp.Controllers;
using System.Web.Mvc;
using System.Linq;

namespace TransApp.Tests.Controllers
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestAddingNewVideoInEmptyTable()
        {
            // Arrange:
            List<Video> video = new List<Video>();
            video.Add(new Video
            {
                vID = 1,
                catID = 1,
                videoName = "Kalli"
            });

            var mockRepo = new Mocks.MockVideoRepository(video);
            var controller = new VideoController(mockRepo);
            
            // Act:
            var result = controller.AddTranslation();

            // Assert:
            var viewResult = (ViewResult)result;
            List<Video> model = (viewResult.Model as IEnumerable<Video>).ToList();
            
            Assert.IsTrue(model.Count == 1);
        }

        [TestMethod]
        public void TestAddingManyVideosInTheTable()
        {
            // Arrange:
            List<Video> videos = new List<Video>();

            for(int i = 0; i < 10; i++)
            {
                videos.Add(new Video
                {
                    vID = i,
                    catID = i,
                    videoName = "GrumpyCat"
                });
            }
            
            var mockRepo = new Mocks.MockVideoRepository(videos);
            var controller = new VideoController(mockRepo);

            // Act:
            var result = controller.AddTranslation();
            
            // Assert:
            var viewResult = (ViewResult)result;
            List<Video> model = (viewResult.Model as IEnumerable<Video>).ToList();

            Assert.IsTrue(model.Count == 10);
        }

    }
}