<?php

include_once 'dbplayers.php';


if(true)
{    
     $name = mysqli_real_escape_string($conn,$_GET['name']); 
	 
     $country = $_GET['country'];
     $creationDatetime = $_GET['creationDatetime'];


     $sql = "INSERT INTO players (name,country,creationDatetime)
     VALUES ('$name' ,'$country','$creationDatetime')";
     if (mysqli_query($conn, $sql)) {
        echo "New record has been added successfully! ";

        $last_id = $conn->insert_id;
        echo "New player record created successfully. Last inserted PlayerID is: " . $last_id;
     } else {
        echo "Error: " . $sql . ":-" . mysqli_error($conn);
     }
     mysqli_close($conn);
}
?>