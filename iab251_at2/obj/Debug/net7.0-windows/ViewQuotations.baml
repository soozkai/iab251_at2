   M S B A M L   `   `   `  ����  
iab251_at2    iab251_at2.ViewQuotations   5   	   W SPresentationCore, Version=7.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=7.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=7.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=7.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=7.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	     � Title$  View Quotations��5   	   $	��600��6!   $	��800��6.    � WindowStartupLocation$ CenterScreen=�5   	   ���#FFFFFF.��5      �  � RowDefinitions 5   
   �� 5	      $��* �6   �� 5
      $
��Auto �6   .+�5   
   �� $��Quotation List��6   $��24(�6*   $
��Bold"�68   $��Center=�5      $��0, 10, 0, 20q�61   ���#FF8C00$��0��5      &   System.Windows.Controls.DataGrid  5   
   -   5          Name$ QuotationDataGrid��5         AutoGenerateColumns$ False��6.      
IsReadOnly$
 True��6J   $��Stretch=�5      $��Stretch=�61   $��10q�6M      Columns 5      0  *System.Windows.Controls.DataGridTextColumn  5      ,  &System.Windows.Controls.DataGridColumn   Header$ Quotation Number��6%      Width5  /System.Windows.Controls.DataGridLengthConverter$ * 6c   1  +System.Windows.Controls.DataGridBoundColumn	   Binding	 6?   �� *QuotationNumber+6c     5      $ Client Name��6%   $ * 6Y   	 6:   �� *
ClientName+6Y     5      $ Date Issued��6%   $ * 6i   	 6:   �� *
DateIssued+
 �� StringFormat$
 d��6i     5      $ Status��6%   $ * 6P   	 65   �� *Status+6P     5      $ Customer Decision��6%   $ * 6]   	 6@   �� *
Decision+6]   5      �� 5!   
    �� Orientation$ 
Horizontal=�6   $��Center=�6.   $��	0,20,0,10q�6K   $��1��6^   .+�5"      �� -   5         ��Name$ AcceptButton��5"      $��Accept��6+   $��40��6W   $	��100��6c   ���#FF8C00
�������$
��Bold"�5#   =   $��0,0,10,0q�6O   �� 5$      -   5        $ RejectButton��5$      $��Reject��6+   $��40��6W   $	��100��6c   
�������
�������$
��Bold"�5%   :   5&      5'      5(      