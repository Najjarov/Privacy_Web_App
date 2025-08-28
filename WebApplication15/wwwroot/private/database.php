<?php

	$db_server = "localhost";
	$db_user = "u252275895_pleaseeeprivac";
	$db_pass = "3DS-S+-7vGCtbxM";
	$db_name = "u252275895_site_db";
	
	try{
	$conn = mysqli_connect($db_server,
						   $db_user,
						   $db_pass,
						   $db_name);
	}
	catch(mysqli_sql_exception){
		echo "could not connect!";
	}
	if($conn){
		//echo "connected";
	}
	else{
		//echo "failed";
	}