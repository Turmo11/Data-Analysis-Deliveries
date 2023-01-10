<?php
    $servername='localhost';
    $username='guillemtg1';
    $password='AEJ6AExX6V';
    $dbname = "guillemtg1";
    $conn=mysqli_connect($servername,$username,$password,"$dbname");
      if(!$conn){
          die('Could not Connect MySql Server:' .mysql_error());
        }
      if($conn){
            echo('Success connecting to database! <br><br>');
        }
?>