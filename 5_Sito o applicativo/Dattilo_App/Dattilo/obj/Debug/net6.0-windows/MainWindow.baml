   M S B A M L   `   `   `  ????B  >Dattilo, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null!clr-namespace:DattiloDattilo  5   	   -clr-namespace:Dattilo.ViewsDattilo.Views  5   	   7 clr-namespace:Dattilo.ViewModelsDattilo.ViewModels  5   	       Dattilo.MainWindow   5   	   W SPresentationCore, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   'localclr-namespace:Dattilo     5   	   -viewsclr-namespace:Dattilo.Views     5   	   7
viewmodels clr-namespace:Dattilo.ViewModels     5   	     ? Title$  
MainWindow??5
   	   $	??450??6   $	??800??6)    ? DataContext 5      &    Dattilo.ViewModels.MainViewModel  5   
    ? 	Resources 5       ?? DataType/   )Dattilo.ViewModels.ApprendimentoViewModel%   Dattilo.Views.ApprendimentoView+  %Dattilo.ViewModels.DettaturaViewModel!   Dattilo.Views.DettaturaView&    Dattilo.ViewModels.MenuViewModel   Dattilo.Views.menuView??%?   (??       5      *, +)(?? 2     5      *, +)(?? d     5      *, +)?? 5   
   "  6   .R?5        5      ?? 5   
   "  6   .R?5        5      ?? 5   
   "  6   .R?5        5      5      .??5      ?  ? RowDefinitions 5   
   ?? 5      $	??10* ?6   ?? 5      $??* ?6   .+?5!   
   ?? $??2??6?   $??2??6S   ??6   ?? *SelectedViewModel+6S   ?? 5"   
   $??Apprendimento??6   $??1??6)   $??center=?66   $
??Left=?6Q   $??Apprendimento??6?   ??6l   ?? *UpdateViewCommand+6?   ?? 5#   
   $??	Dettatura??6   $??1??6%   $??center=?62   $??Right=?6M   $??	Dettatura??6?   ??6i   ?? *UpdateViewCommand+6?   ?? 5$   
   $
??Menu??6   $??1??6    $??center=?6-   $??center=?6H   $
??Menu??6?   ??6e   ?? *UpdateViewCommand+6?   5%      5&      