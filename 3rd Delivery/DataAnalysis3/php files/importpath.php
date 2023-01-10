<?php

include_once 'settings.php';

$sql = "SELECT x, y, z FROM Position";
$result = $conn->query($sql);

if ($result->num_rows > 0) {
  // output data of each row
  while($row = $result->fetch_assoc()) {
    echo "" . $row["x"]. " " . $row["y"]. " " . $row["z"]. "<br>";
  }
} else {
  echo "0 results";
}
$conn->close();

?>