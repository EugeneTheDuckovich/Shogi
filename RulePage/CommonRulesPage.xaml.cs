using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Shogi.RulePage
{
    /// <summary>
    /// Логика взаимодействия для CommonRulesPage.xaml
    /// </summary>
    public partial class CommonRulesPage : Page
    {
        public CommonRulesPage()
        {
            InitializeComponent();
            CommonRulesText.Text = "Сьогі (яп. 将棋 сьо:гі, «гра генералів»; [ɕo̞ːgi])  - це настільна стратегічна гра для двох, японський аналог шахів. " +
                "Гра йде на дошці 9х9, мета гри ідентична шахам - поставити мат королю супротивника. " +
                " Фігури мають форму п'ятикутників, на яких ієрогліфом показано силу фігури. " +
                "Деякі з фігур в певних умовах можуть перетворюватися в інші, " +
                "аналогічно тому, як у шахах пішак може перетворитися в будь-яку іншу фігуру, досягнувши восьмої лінії. " +
                "Тому на зворотній стороні певних фігур написаний інший ієрогліф — потенційна сила фігури. " +
                "На початку гри в розпорядженні двох гравців, яких традиційно називають сенте і готе, по 20 фігур: " +
                "король, тура, слон, два золоті генерали, два срібні генерали, два коні, два списи і дев'ять пішаків. ";
        }
    }
}
