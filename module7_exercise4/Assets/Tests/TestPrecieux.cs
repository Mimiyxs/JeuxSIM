using NUnit.Framework;
using System.Collections.Generic;

public class TestPrecieux : IPrecieux { public int Valeur { get; set; } 


    [Test]
    public void TrouverPlusPrecieux_Simple1()
    {
        // Arrange
        List<TestPrecieux> precieuxListe = new() {
            new TestPrecieux { Valeur = 10 },
            new TestPrecieux { Valeur = 50 },
            new TestPrecieux { Valeur = 20 }
        };
        // Act
        IPrecieux plusPrecieux = Utilitaires.TrouverPlusPrecieux(precieuxListe);
        // Assert
        Assert.AreEqual(50, plusPrecieux.Valeur);
    }

    [Test]
    public void TrouverMoinsPrecieux()
    {
        List<TestPrecieux> precieuxListe = new() {
            new TestPrecieux { Valeur = 10 },
            new TestPrecieux { Valeur = 50 },
            new TestPrecieux { Valeur = 20 }
        };
        IPrecieux moinsPrecieux = Utilitaires.TrouverMoinsPrecieux(precieuxListe);
        Assert.AreEqual(10, moinsPrecieux.Valeur);
    }

}