   M S B A M L   `   `   `  ����E  AGattileWPF, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null'clr-namespace:GattileWPF
GattileWPF  5   	   $    GattileWPF.WindowAggiungiGatto   5   	   W SPresentationCore, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   *localclr-namespace:GattileWPF     5   	     � Title$  WindowAggiungiGatto��5   	   $	��450��6%   $	��800��62    � 
ResizeMode$ NoResize=�6>   .��5	      � .+�5
   
   �� -   5        $��Aggiungi��5
      $
��Left=�6$   $��55��6?   $��591,283,0,0q�6K   $	��Top=�6`   $	��115��6x   $��18(�6�   6�   �� 5   
   -   5         ��Name$ lblNome��5      $��Nome:��6!   $
��Left=�61   $��Center=�6L   $��100,113,0,0q�6n   $	��Top=�6�   $��48��6�   $��31��6�   �� 5   
   -   5        $ lblRazza��5      $��Razza:��6"   $
��Left=�63   $��Center=�6N   $��295,116,0,0q�6p   $	��Top=�6�   $��44��6�   $��32��6�   �� 5   
   -   5        $ lblSesso��5      $��Sesso:��6"   $
��Left=�63   $��Center=�6N   $��505,119,0,0q�6p   $	��Top=�6�   $��45��6�   $��32��6�   �� 5   
   -   5        $ lblDataArrivo��5      $��Data Arrivo:��6'   $
��Left=�6>   $��Center=�6Y   $��100,159,0,0q�6{   $	��Top=�6�   $��81��6�   $��32��6�   �� 5   
   -   5        $ lblDataUscita��5      $��Data Uscita:��6'   $
��Left=�6>   $��Center=�6Y   $��100,194,0,0q�6{   $	��Top=�6�   $��81��6�   $��32��6�   �� 5   
   -   5        $ lblDataNascita��5      $��Data Nascita:��6(   $
��Left=�6@   $��Center=�6[   $��100,226,0,0q�6}   $	��Top=�6�   $��81��6�   $��32��6�   �� 5   
   -   5        $ lblDescrizione��5      $��Descrizione: ��6(   $
��Left=�6@   $	��Top=�6[   $��305,159,0,0q�6z   $	��Top=�6�   $��78��6�   $��24��6�    J� RenderTransformOrigin$ 0.449,0.571&�6�   �� 5   
   -	   5         ��Name$ txbNome��5      $
��Left=�6#   $��25��6>   $��153,119,0,0q�6J    �� TextWrapping$
 Wrap=�6_   $	��Top=�6s   $	��137��6�   �� 5   
   -
   5         ��Name$ 	cmbxRazza��5      $
��Left=�6&   $��25��6A   $��339,118,0,0q�6M   $	��Top=�6b   $	��156��6z   �� 5   
   -   5        $ 	cmbxSesso��5      $
��Left=�6&   $��25��6A   $��550,121,0,0q�6M   $	��Top=�6b   $	��156��6z   (  "System.Windows.Controls.DatePicker  5   
   -   5          Name$ datepArrivo��5      $
��Left=�6*   $��181,162,0,0q�6E   $	��Top=�6Z   $	��112��6r   $��25��6~     5   
   -   5        $ datepUscita��5      $
��Left=�6*   $��181,196,0,0q�6E   $	��Top=�6Z   $	��112��6r   $��25��6~     5   
   -   5        $ datepNacita��5      $
��Left=�6*   $��181,230,0,0q�6E   $	��Top=�6Z   $	��112��6r   $��25��6~   �� 5   
   -   5        $ txbDescrizione��5      $
��Left=�6*   $��76��6E   $��	308,0,0,0q�6Q   $
 Wrap=�6d   $��Center=�6x   $	��398��6�   �� 5   
   -   5        $ lblError��5      $�� ��6"   $��Center=�6-   $��Center=�6Q   $��100,283,214,0q�6s   $	��Top=�6�   $��55��6�   $��18(�6�   �� 5   
   -   5         ��Name$ ckbxUscitaSconosciuta��5      $��
Sconoscita��62   $
��Left=�6G   $��
16,202,0,0q�6b   $	��Top=�6v   $��79��6�   6�   �� 5   
   -   5        $ ckbxNascitaSconosciuta��5      $��
Sconoscita��63   $
��Left=�6H   $��
16,234,0,0q�6c   $	��Top=�6w   $��79��6�   6�   5      5      