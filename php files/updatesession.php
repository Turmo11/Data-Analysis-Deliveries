<?php

include_once 'dbplayers.php';


if(true)
{    
     $sessionID = $_GET['sessionID'];
     $sessionEnd = $_GET['sessionEnd'];

     $sql = "UPDATE sessions
     SET  sessionEnd = '$sessionEnd'
	 WHERE sessionID = '$sessionID'";
     if (mysqli_query($conn, $sql)) {
        echo "New record has been added successfully! ";

        $last_id = $conn->insert_id;
        echo "New endSession record updated successfully. Last inserted SessionID is: " . $last_id;
     } else {
        echo "Error: " . $sql . ":-" . mysqli_error($conn);
     }
     mysqli_close($conn);
}
?>