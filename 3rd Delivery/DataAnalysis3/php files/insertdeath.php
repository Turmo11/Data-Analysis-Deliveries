<?php

include_once 'settings.php';


if(true)
{    
   
   $x = $_GET['x']; 
   $y = $_GET['y'];
   $z = $_GET['z'];
  

   $sql = "INSERT INTO Death (x,y,z)
   VALUES ('$x' ,'$y','$z')";
   if (mysqli_query($conn, $sql)) {
      echo "New record has been added successfully! ";

      $last_id = $conn->insert_id;
      echo "New death record created successfully.";
   } else {
      echo "Error: " . $sql . ":-" . mysqli_error($conn);
   }
   mysqli_close($conn);
}
?>