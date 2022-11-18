<?php

include_once 'dbplayers.php';


if(true)
{    
     $sessionID = $_GET['sessionID']; 
     $itemID = $_GET['itemID'];
     $purchaseDatetime = $_GET['purchaseDatetime'];
	 

     $sql = "INSERT INTO transactions (sessionID,itemID,purchaseDatetime)
     VALUES ('$sessionID' ,'$itemID','$purchaseDatetime')";
     if (mysqli_query($conn, $sql)) {
        echo "New record has been added successfully! ";

        $last_id = $conn->insert_id;
        echo "New transaction record created successfully.";
     } else {
        echo "Error: " . $sql . ":-" . mysqli_error($conn);
     }
     mysqli_close($conn);
}
?>