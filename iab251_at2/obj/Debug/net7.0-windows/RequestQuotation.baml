   M S B A M L   `   `   `  ����  
iab251_at2!    iab251_at2.RequestQuotation   5      W SPresentationCore, Version=7.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=7.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=7.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=7.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5      R NSystem.Xaml, Version=7.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5        N� Title$  Request Quotation��5       N� 
Background �#FFFFFF � 	Resources 5      3  -System.Windows.Media.Effects.DropShadowEffect   DropShadowEffect   
BlurRadius   ShadowDepth   Opacity   Color��%S   &	          5   
   $ 10Q�64   $ 5Q�6D   $	 0.5Q�6T   $ Black��6b   5	      .��5      � $��Center=�6   $��Center=�6(   $��40q�6C   .+�5   
   �� 
����������#E0E0E0$��1q�6:    �� CornerRadius$ 10��6N    �� Padding$ 20q�6`   $��Center=�5      $��Center=�6.   $	��600��6I   	 J� Effect#	 [  6U   ._�5      �� .+�5      �� $��Request Quotation��6   $��28(�65   $
��Bold"�6C   ���#FF8C00$��0,0,0,20q�6j   $��Center=�6|   �� 5      $
��Left=�6   $��20q�68   $	��531��6D   .+�5      �� $��Request ID:��6    $
��Bold"�63   �� 5      -   5        
 ��Name$
 RequestIDTextBox��5      $��0,0,0,10q�68   �� 5      $��Customer Name:��6    $
��Bold"�66   �� 5      -   5        $
 NameTextBox��5      $��0,0,0,10q�63   �� 5      $��Email:��6    $
��Bold"�6.   �� 5      -   5        $
 EmailTextBox��5      $��0,0,0,10q�64   �� 5       $��Source Location:��6    $
��Bold"�68   �� 5!      -   5        $
 SourceTextBox��5!      $��0,0,0,10q�65   �� 5$      $��Destination Location:��6    $
��Bold"�6=   �� 5%      -   5        $
 DestinationTextBox��5%      $��0,0,0,10q�6:   �� 5(      $��Number of Containers:��6    $
��Bold"�6=   �� 5)      -   5        $
 ContainersTextBox��5)      $��0,0,0,10q�6:   �� 5,      $��Nature of the Package:��6    $
��Bold"�6>   �� 5-      -   5        $
 PackageNatureTextBox��5-      $��0,0,0,10q�6<   �� 50      $��Nature of the Job:��6    $
��Bold"�6:   �� 51      -   5         ��Name$ JobNatureComboBox��51      $��0,0,0,10q�6:   .@�52      �� $��Import��6'   �� 53      $��Export��6'   �� 54      $	��N/A��6'   55      �� 56      -	   5        $ PackingComboBox��56      $��0,0,0,10q�68   .@�57      �� $��Packing��6'   �� 58      $��	Unpacking��6'   �� 59      $
��Both��6'   �� 5:      $
��None��6'   5;      �� 5=      $��Quarantine Requirements:��6    $
��Bold"�6@   �� 5>      -
   5        $
 QuarantineTextBox��5>      $��0,0,0,10q�69   �� 5A      $��Request Date:��6    $
��Bold"�65   (  "System.Windows.Controls.DatePicker  5B      -   5          Name$ RequestDatePicker��5B   !   $��0,0,0,10q�6<   5C      �� 5F       �� Orientation$ 
Horizontal=�6   $��Center=�66   $��0,20,0,0q�6S   .+�5G      �� -   5        $��Submit Request��5G      $	��120��6R   $��10q�6^   ���#4CAF50
�������6   �� 5H      $��Cancel��6   $	��120��6.   $��10q�6:   ���#F44336
�������6[   5I      5J      5K      5L      5M      