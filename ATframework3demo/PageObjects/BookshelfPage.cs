using atFrameWork2.SeleniumFramework;

namespace ATframework3demo.PageObjects
{
    public class BookshelfPage
    {
        WebItem BookshelfTags(int i) => new WebItem($"//div[@class='book-detail-card-description-genres-links']//child::p[{i}]", "Тэги на странице полки");

        public int CheckIfTagsExist(int i, int x) //i=количество проходов while, x=номер тэга
        {
            while (i < 3)
            {
                if (BookshelfTags(x).WaitElementDisplayed(1))
                {
                    i++;
                    x++;
                }
                else i = 50;
            }
            return i;
        }

    }
}
