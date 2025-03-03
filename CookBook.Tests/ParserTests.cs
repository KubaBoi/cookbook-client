﻿using CookBook.Models;
using System.Text.Json;

namespace CookBook.Tests;
public class ParserTests
{
    [Fact]
    public void Parse_JsonRecipe_ReturnModel()
    {
        string json = "{\"ingredients\": [{\"name\": \"cibule\", \"amount\": 2, \"unit\": \"ks\", \"amount_str\": \"2\"}, {\"name\": \"žampiony\", \"amount\": 200, \"unit\": \"g\", \"amount_str\": \"200\"}], \"name\": \"Pastýřský koláč\", \"header\": {\"duration\": \"95 minut\", \"difficulty\": \"snadné\", \"portions\": 4, \"portion_unit\": \"porce\"}, \"steps\": [\"Cibuli nasekejte najemno, mrkev s celerem nakrájejte na kostky, česnek a žampiony na plátky.\", \"Na rozehřátém másle zpěňte cibuli a za mírné teploty 15 minut restujte mrkev, celer a česnek. Přidejte žampiony, zvyšte teplotu a restujte ještě 5 minut.\", \"Nyní k zelenině nasypte čočku. Přidejte bobkový list a tymián, zalijte vývarem a vařte pod pokličkou asi 40 minut. Hrnec odstavte, čočku osolte, opepřete a vmíchejte rajčatový protlak. 4. Mezitím nakrájejte na kousky oloupané brambory, uvařte je doměkka v osolené vodě, slijte a rozmačkejte s máslem na pyré.\", \"Čočku přesuňte do zapékací nádoby, překryjte bramborovou kaší a při 180 °C asi 30 minut zapékejte. Ihned podávejte.\", \"Recept pro vás připravil časopis F.\", \"O.\", \"O.\", \"D.\"], \"source\": \"https://www.recepty.cz/recept/pastyrsky-kolac-164925\"}";

        var recipe = JsonSerializer.Deserialize<Recipe>(json);

        Assert.NotNull(recipe);
        Assert.Equal("Pastýřský koláč", recipe.Name);
        Assert.Equal("https://www.recepty.cz/recept/pastyrsky-kolac-164925", recipe.Source);
        Assert.Equal(8, recipe.Steps.Count);
        Assert.NotNull(recipe.Header);
        Assert.Equal("95 minut", recipe.Header.Duration);
        Assert.Equal("snadné", recipe.Header.Difficulty);
        Assert.Equal(4, recipe.Header.Portions);
        Assert.Equal("porce", recipe.Header.PortionUnit);

        Assert.Equal(2, recipe.Ingredients.Count);
        Assert.Equal("cibule", recipe.Ingredients[0].Name);
        Assert.Equal(2, recipe.Ingredients[0].Amount);
        Assert.Equal("2", recipe.Ingredients[0].AmountText);
        Assert.Equal("ks", recipe.Ingredients[0].Unit);
        Assert.Equal("žampiony", recipe.Ingredients[1].Name);
        Assert.Equal(200, recipe.Ingredients[1].Amount);
        Assert.Equal("200", recipe.Ingredients[1].AmountText);
        Assert.Equal("g", recipe.Ingredients[1].Unit);
    }

    [Fact]
    public void Test()
    {
        string json = "{\"id\":\"ec6205f6-59f7-4eac-bbc4-244de03f3538\",\"name\":\"Brokolicov\\u00E1 pol\\u00E9vka se smetanou\",\"source\":\"https://www.recepty.cz/recept/brokolicova-polevka-se-smetanou-145785\",\"header\":{\"duration\":\"10 minut\",\"difficulty\":\"snadn\\u00E9\",\"portions\":4,\"portion_unit\":\"porce\"},\"steps\":[\"V\\u00A0hrnci na m\\u00E1sle a na mal\\u00E9m plameni osma\\u017Ete cibuli. P\\u0159idejte brokolici a brambory a zalijte v\\u00FDvarem. Va\\u0159te, a\\u017E jsou brambory a brokolice m\\u011Bkk\\u00E9.\",\"Potom pol\\u00E9vku rozmixujte na jemn\\u00FD kr\\u00E9m, p\\u0159ilijte smetanu a podle chuti osolte a opep\\u0159ete. Nechte je\\u0161t\\u011B kr\\u00E1tce proj\\u00EDt varem. Na tal\\u00ED\\u0159i zdobte krutony.\"],\"ingredients\":[[\"cibule\",\"1 ks\"],[\"brambory\",\"3 ks\"],[\"m\\u00E1slo\",\"2 l\\u017E\\u00EDce\"],[\"\",\"s\\u016Fl\"],[\"\",\"pep\\u0159 mlet\\u00FD\"],[\"smetana\",\"1 kel\\u00EDmek\"],[\"dr\\u016Fbe\\u017E\\u00ED v\\u00FDvar\",\"1 l\"],[\"brokolice\",\"500 g\"],[\"\",\"krutony\"]]}";
        
        var recipe = JsonSerializer.Deserialize<Recipe>(json);
    }
}

