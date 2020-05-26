using DataLayer;
using DomainLibrary;
using DomainLibrary.Domain;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Linq;
using System.Transactions;

namespace UnitTestDataLayer
{
    [TestClass]
    public class TrainingManagerTest
    {

        TrainingManager m = new TrainingManager(new UnitOfWork(new TrainingContextTests()));

        [TestMethod]
        [ExpectedException(typeof(DomainException), "Training is in the future")]
        public void TestAddCyclingTraining_InTheFuture_throwExcep()
        {
            //het jaar 2028 is in de toekomst
            //iemand vergiste de jaar
            m.AddCyclingTraining(new DateTime(2028, 4, 21, 16, 00, 00), 40, new TimeSpan(1, 20, 00), 30, null, TrainingType.Endurance, null, BikeType.RacingBike);

        }

        [TestMethod]
        [ExpectedException(typeof(DomainException), "Distance invalid value")]
        public void TestAddCyclingTraining_InvalidDistance_throwExcep()
        {
            //mag mag 500 zijn maar is 560
            //dat zijn veel km's
            m.AddCyclingTraining(new DateTime(2020, 4, 21, 16, 00, 00), 560, new TimeSpan(1, 20, 00), 30, null, TrainingType.Endurance, null, BikeType.RacingBike);

        }

        [TestMethod]
        public void TestAddCyclingTraining_Gem_nietGegeven_SnelheidKlopt()
        {
            m.AddCyclingTraining(new DateTime(2020, 4, 18, 18, 00, 00), 40, new TimeSpan(1, 42, 00), null, null, TrainingType.Recuperation, null, BikeType.RacingBike);
            Assert.IsTrue(m.GetAllCyclingSessions().Last().AverageSpeed.Value.Equals((float)(m.GetAllCyclingSessions()[0].Distance / m.GetAllCyclingSessions()[0].Time.TotalHours)));
        }


        [TestMethod]
        public void TestAddCyclingTraining_Gem_nietGegeven_GeenAfstand_Exception()
        {

            m.AddCyclingTraining(new DateTime(2020, 4, 18, 18, 00, 00), null, new TimeSpan(1, 42, 00), null, null, TrainingType.Recuperation, null, BikeType.RacingBike);
            // nullable object mag niet null zijn
            //"to obtain average speed: you'll need both distance and time OR fill in average speed"
            Assert.ThrowsException<InvalidOperationException>(() => m.GetAllCyclingSessions().Last().AverageSpeed.Value);


        }

        //
        [TestMethod]
        [ExpectedException(typeof(DomainException), "Training is in the future")]
        public void TestAddRunningTraining_InTheFuture_throwExcep()
        {
            //het jaar 2028 is in de toekomst
            //iemand vergiste de jaar
            m.AddRunningTraining(new DateTime(2028, 3, 17, 11, 0, 00), 8000, new TimeSpan(0, 42, 10), null, TrainingType.Endurance, null);

        }

        // integ test
        [TestMethod]
        public void ProductTest()
        {
            // Arrange
            using (new TransactionScope())
            {
                TrainingContextTests db = new TrainingContextTests();
                var originalCount = db.CyclingSessions.ToList().Count();
                CyclingSession x = new CyclingSession(new DateTime(2020, 4, 21, 16, 00, 00), 40, new TimeSpan(1, 20, 00), 30, null, TrainingType.Endurance, null, BikeType.RacingBike);


                // Act
                db.CyclingSessions.Add(x);
                db.SaveChanges();

                // Assert
                 Assert.AreEqual(originalCount + 1, db.CyclingSessions.ToList().Count());

            }

        }

    }
}
