using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using WindowsFormsApp1;

using Google.Apis.Auth.OAuth2;
using Google.Apis.Services;
using Google.Apis.Sheets.v4;
using Newtonsoft.Json;
using Data = Google.Apis.Sheets.v4.Data;
using System.Threading;
using Google.Apis.Util.Store;
using System.IO;

using Google.Apis.Storage.v1.Data;
using Google.Cloud.Storage.V1;

namespace WindowsFormsUnitTests
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void ReturnsFive()
        {
            DeckListForm form2 = new DeckListForm();
            Assert.AreEqual(5, form2.returnFive());
        }
    }
}
