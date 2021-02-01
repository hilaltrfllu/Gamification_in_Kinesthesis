<?php
if($_SESSION["username"]){
?>
                <div class="alert alert-success" role="alert">
                        <p class="alert-link text-right">Welcome, <?php echo $_SESSION["username"]; ?> </p>
                </div>
<?php
}else{header("Location:index.html");}
?>