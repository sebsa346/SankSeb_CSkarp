using Microsoft.VisualStudio.TestTools.UnitTesting;
using SanSebKalaha;
using System;

namespace UnitTestSanSeb
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void SetGameField()
        {
            // arrange
            int startingMarblesStandard = 0;
            int expected = 3;
            var rm = new RuleMaster();
            // act
            rm.gameRules(startingMarblesStandard);
            int actual = rm.arrayTest[3]; 
            // assert
            Assert.AreEqual(expected, actual);
        }

        // Testar ifall "facken" uppdateras som de bör när en "Capture" sker. 
        // I det här fallet klickar användaren "You" på ett "fack" som innerhåller 3 kulor 
        // där sista kula hamnar i ett "fack" som tidigare har 0 kulor. Då åker den kulan in i användarens bo + de kulor
        // som finns hot motspelare på "facket" mittemot.
        [TestMethod]
        public void CaptureIsMade()
        {
            // Innan en "Capture".

            // arrange 1
            int startingMarbles = 0;
            int expectedAtPos0Before = 3;
            int expectedAtPos1Before = 3;
            int expectedAtPos2Before = 3;
            int expectedAtPos3Before = 0;
            int expectedAtPos9Before = 3;
            int expectedAtHomeBefore = 0;
            var rm = new RuleMaster();
            // act 1
            rm.gameRules(startingMarbles);
            rm.arrayTest[3] = 0;
            int actualAtPos0Before = rm.arrayTest[0];
            int actualAtPos1Before = rm.arrayTest[1];
            int actualAtPos2Before = rm.arrayTest[2];
            int actualAtPos3Before = rm.arrayTest[3];
            int actualAtPos9Before = rm.arrayTest[9];
            int actualAtHomeBefore = rm.arrayTest[6];
            // assert 1
            Assert.AreEqual(expectedAtPos0Before, actualAtPos0Before);
            Assert.AreEqual(expectedAtPos1Before, actualAtPos1Before);
            Assert.AreEqual(expectedAtPos2Before, actualAtPos2Before);
            Assert.AreEqual(expectedAtPos3Before, actualAtPos3Before);
            Assert.AreEqual(expectedAtPos9Before, actualAtPos9Before);
            Assert.AreEqual(expectedAtHomeBefore, actualAtHomeBefore);

            // Efter att en "Capture" har uppstått.

            // arrange 2
            int EllipsePos = 0;
            int expectedAtPos0After = 0;
            int expectedAtPos1After = 4;
            int expectedAtPos2After = 4;
            int expectedAtPos3After = 0;
            int expectedAtPos9After = 0;
            int expectedAtHomeAfter = 4;
            // act 2
            rm.MouseDownEllipsee(EllipsePos);
            int actualAtPos0After = rm.arrayTest[0];
            int actualAtPos1After = rm.arrayTest[1];
            int actualAtPos2After = rm.arrayTest[2];
            int actualAtPos3After = rm.arrayTest[3];
            int actualAtPos9After = rm.arrayTest[9];
            int actualAtHomeAfter = rm.arrayTest[6];
            // assert 2
            Assert.AreEqual(expectedAtPos0After, actualAtPos0After);
            Assert.AreEqual(expectedAtPos1After, actualAtPos1After);
            Assert.AreEqual(expectedAtPos2After, actualAtPos2After);
            Assert.AreEqual(expectedAtPos3After, actualAtPos3After);
            Assert.AreEqual(expectedAtPos9After, actualAtPos9After);
            Assert.AreEqual(expectedAtHomeAfter, actualAtHomeAfter);
        }

        // Testar ifall "facken" uppdateras korrekt när en användarens kulor överstigen dennes egna "fack"
        // så att kulorna ska hamna i motspelarens "fack". 
        // I det här fallet klickar spelare2 på sitt sista "fack" som innehåller 3 kulor(standard). En kul bör du hamna i
        // dennes Bo, sedan bör en kula hamna i motspelarens första "fack" samt dennes andra "fack".
        [TestMethod]
        public void ClickAtEllipseUpdatesCorrectlyForTheWholePlayField()
        {
            // arrange
            int EllipsePos = 12;
            int startingMarbles = 0;
            int expectedAtPos12 = 0;
            int expectedAtPlayer2Home = 1;
            int expectedAtPos0 = 4;
            int expectedAtPos1 = 4;
            int expectedAtPos2 = 3;
            var rm = new RuleMaster();
            // act
            rm.gameRules(startingMarbles);
            rm.playersTurn.WhosTurn = "George";
            rm.MouseDownEllipsee(EllipsePos);
            int actualAtPos12 = rm.arrayTest[12];
            int actualAtPlayer2Home = rm.arrayTest[13];
            int actualAtPos0 = rm.arrayTest[0];
            int actualAtPos1 = rm.arrayTest[1];
            int actualAtPos2 = rm.arrayTest[2];
            // assert
            Assert.AreEqual(expectedAtPos12, actualAtPos12);
            Assert.AreEqual(expectedAtPlayer2Home, actualAtPlayer2Home);
            Assert.AreEqual(expectedAtPos0, actualAtPos0);
            Assert.AreEqual(expectedAtPos1, actualAtPos1);
            Assert.AreEqual(expectedAtPos2, actualAtPos2);
        }
    }
}
