   M S B A M L   `   `   `  ????	  Shogi    Shogi.RulesPage   5      W SPresentationCore, Version=5.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=5.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=5.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=5.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5      R NSystem.Xaml, Version=5.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5        N? Title$  	RulesPage??5      .??5
      ?  ? RowDefinitions 5   
   ?? 5      $
??auto ?6   ?? 5      $??* ?6   ?? 5      $
??auto ?6   $	??600??6*   ?? 5      $??* ?6    ? ColumnDefinitions 5   
   ?? 5      $??* ?6   ?? 5      $
??auto ?6   ?? 5      $??20 ?6   ?? 5      $
??auto ?6   ?? 5      $??20 ?6   ?? 5      $
??auto ?6   ?? 5      $??20 ?6   ?? 5      $
??auto ?6   ?? 5      $??* ?6   .+?5   
   o? $??0??6   $??0??6   $	??Top=?6,   $
??Left=?6D   .@?5      m? $??меню??6   $??20(?6%   .@?5      m? $7??1повернутися в головне меню??6   $??20(?6?    m? Command 6M   ?? *DataContext.BackToMenuCommand+ ?? RelativeSource ??  ?? AncestorType Pagem? 5      $??вийти з гри??6   $??20(?60    6>   ?? *DataContext.ExitCommand+ ??  Page5       5!       ? 5"   
   -   5        $??
RulesFrame??5"      $??1??6"   $??7??62   $??2??6F     ? NavigationUIVisibility$ Hidden=?6S   ?? 5#   
   $#??основні плавила??6   $??1??6+   $??0??6;   $??20(?6H   ??6V   ?? *$"DataContext.GoToCommonRulesCommand+ ??  Page?? 5$   
   $$??Як ходять фігури??6   $??3??6,   $??0??6<   $??20(?6I   ??6W   ?? *&$DataContext.GoToHowPiecesMoveCommand+ ??  Page?? 5%   
   $??Правила ходу??6   $??5??6(   $??0??68   $??20(?6E   ??6S   ?? *&$DataContext.GoToMovementRulesCommand+ ??  Page?? 5&   
   $)??#Перевтілення фігур??6   $??7??6.   $??0??6>   $??20(?6K   ??6Y   ?? *,*DataContext.GoToTransformationRulesCommand+ ??  Page5'      5(      