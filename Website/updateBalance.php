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
        
        $username = $_POST["username"];
	$balance = $_POST["balance"];
        $score = $_POST["score"];
        
        $update = "UPDATE users SET balance='{$balance}', score='{$score}' WHERE username='{$username}'";
        
        mysqli_query($conn, $update) or die ("Error Code #4: Update user query failed");
        echo("Update successful!");
        mysqli_close($conn);
        ?>

	/*//add balance to the table
 	$insertuserquery = "INSERT INTO users (balance) VALUES ('" . $balance . "');";

 	//$insertuserquery = "INSERT INTO users (username, hash) VALUES ('" . $username . "','" . $password . "');";
 	/*bu $insertuserquery = "INSERT INTO users (username, hash) VALUES ('" . $username . "','" . $password . "')";*/
 	mysqli_query($conn, $insertuserquery) or die ("Error Code #4: Insert user query failed");
 	echo("0");
 	mysqli_close($conn);*/
?>