<?php
    $servername='localhost';
    $username='paufl1';
    $password='AuCMGhxrwS';
    $dbname = "paufl1";
    $conn=mysqli_connect($servername,$username,$password,"$dbname");
      if(!$conn){
          die('Could not Connect MySql Server:' .mysql_error());
        }
      if($conn){
            echo('Success connecting to database! ');
        }
?>