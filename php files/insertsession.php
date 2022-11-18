<?php

include_once 'dbplayers.php';


if(true)
{    
     $playerID = $_GET['playerID'];
     $sessionStart = $_GET['sessionStart'];

     $sql = "INSERT INTO sessions (playerID,sessionStart)
     VALUES ('$playerID' ,'$sessionStart')";
     if (mysqli_query($conn, $sql)) {
        echo "New record has been added successfully! ";

        $last_id = $conn->insert_id;
        echo "New record session created successfully. Last inserted SessionID is: " . $last_id;
     } else {
        echo "Error: " . $sql . ":-" . mysqli_error($conn);
     }
     mysqli_close($conn);
}
?>