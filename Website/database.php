<?php
ob_start();
session_start();
$message="";
?>
<html>
<head>
<title>Patients' Table</title>
<style>
table{
border-collapse: collapse;
width: 100%;
color: #0c1248;
font-family: monospace;
font-size: 25px;
text-align: left;
}
button {
  background-color: #d03737;
  color: white;
  font-family: monospace;
  font-size: 16px;
  padding: 14px 20px;
  margin: 8px 0;
  border: none;
  cursor: pointer;
  width: 100%;
  position: sticky;
  left: 1444px;
  top: -2px;
}
button:hover {
  opacity: 0.8;
}
.logoutbtn {
  width: auto;
  padding: 10px 18px;
  background-color: #0c1248;
}
th {
background-color: #d03737;
color: white;
}
tr:nth-child(even) {background-color: #f2f2f2}
</style>
</head>
<body>
<table>
<tr>
<th>Id</th>
<th>Username</th>
<th>Balance</th>
<th>Score</th>
<th>Date</th>
</tr>
<?php
        $conn = mysqli_connect("fdb28.awardspace.net", "3602417_project", "project123", "3602417_project") or die('Unable To connect');
        require_once 'welcome.php';
        $sql = "SELECT user_id, username, balance, score, date FROM users";
        $result = mysqli_query($conn,"SELECT user_id, username, balance, score, date FROM users");
      /*  $row  = mysqli_fetch_array($result);
        if(is_array($row)) {
                $_SESSION["username"] = $row['username'];
        }else{
                $message = "Invalid Username or Password!";
        }*/
      //  if ($result->num_rows > 0) {
              if($_SESSION['username'] != null){
                // output data of each row
                while($row = $result->fetch_assoc()) {
                        echo "<tr><td>" . $row["user_id"]. "</td><td>" . $row["username"] . "</td><td>" . $row["balance"] . "</td><td>" . $row["score"] . "</td><td>" . $row["date"]. "</td></tr>";
                }
                echo "</table>";
                
        }
       /* if(!isset($_SESSION["username"])){
                header("Location:gaminkin.scienceontheweb.net/index.html");
                exit();
        }*/

        mysqli_close($conn);
?>
<form action="logout.php" method="post">
 <div class="container" style="background-color:#f1f1f1">
    <button href="logout.php" class="logoutbtn">LOGOUT</button>
  </div>
</form>
</table>
</body>
</html>


