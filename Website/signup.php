<?php
	$servername = "fdb28.awardspace.net";
	$username = "3602417_project";
	$password = "project123";
	$database = "3602417_project";

	$conn = mysqli_connect($servername, $username, $password, $database);
	
	//check that connection happen
	/*if(mysqli_connect_errno()){
		echo "Error Code #1: Connection failed!";
		exit();
	}*/
	if (!$conn) {
    	die("Connection failed: " . mysqli_connect_error());
	}

	$username = $_POST["name"];
	$password = $_POST["password"];

	//check if name exists
	$namecheckquery = "SELECT username FROM users WHERE username='" . $username . "';";
	$namecheck = mysqli_query($conn, $namecheckquery) or die("Error Code #2: Name check query failed");
	if (mysqli_num_rows($namecheck) > 0){
		echo "Error Code #3: Name already exists";
		exit();
	}

	//add user to the table
	$salt = "\$5\$rounds=1000\$" . "hilal" . $username . "\$"; // SHA-256
	$hash = crypt($password, $salt);
 	$insertuserquery = "INSERT INTO users (username, hash, salt) VALUES ('" . $username . "','" . $hash . "','" . $salt . "');";
        require_once ('sendemail.php');
 	//$insertuserquery = "INSERT INTO users (username, hash) VALUES ('" . $username . "','" . $password . "');";
 	/*bu $insertuserquery = "INSERT INTO users (username, hash) VALUES ('" . $username . "','" . $password . "')";*/
 	mysqli_query($conn, $insertuserquery) or die ("Error Code #4: Insert user query failed");
 	echo("0");
 	mysqli_close($conn);
?>