<?php
session_start();
$message="";
if(count($_POST)>0){
        $servername = "fdb28.awardspace.net";
        $username = "3602417_project";
        $password = "project123";
        $database = "3602417_project";

        $conn = mysqli_connect($servername, $username, $password, $database);
        
        //check that connection happen
        if(mysqli_connect_errno()){
                echo "Error Code #1: Connection failed!";
                exit();
        }
        if (!$conn) {
        die("Connection failed: " . mysqli_connect_error());
        }

        $username = $_POST["name"];
        $password = $_POST["password"];

        //check if name exists
        $namecheckquery = "SELECT username, user_id, a_salt, a_hash FROM admin WHERE username='" . $username . "';";
        $namecheck = mysqli_query($conn, $namecheckquery) or die("Error Code #2: Name check query failed");
        if (mysqli_num_rows($namecheck) != 1){
                echo "Error Code #5: Either no user with name or more than 1 exists";
                exit();
        }else{
                $_SESSION["username"] = $username;
        }
        
        //get login info from query
        $existlogininfo = mysqli_fetch_assoc($namecheck);
        $salt = $existlogininfo["a_salt"];
        $hash = $existlogininfo["a_hash"];
        $loginhash = crypt($password, $salt);
        if ($hash != $loginhash){
                echo "Error Code #6: Incorrect password, password does not hash to match table";
                exit();
        }
}
//echo("0\t" . $existlogininfo["score"]);
//echo("0\t" . $existlogininfo["balance"]);

//echo("0");
//header("Location: http://gaminkin.scienceontheweb.net/database.html");

if($_SESSION["username"]){
        header("Location: database.php");
     // echo '<br /><a href="database.php"'. SID . '">Table Page</a>';
        exit();
}else{
        header("Location: index.html");
}
mysqli_close($conn);
?>