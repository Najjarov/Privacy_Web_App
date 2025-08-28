<?php
include 'database.php'; // Your database connection file

$stmt = $conn->query("SELECT id, password FROM users");

while ($user = $stmt->fetch(PDO::FETCH_ASSOC)) {
    $hashedPassword = password_hash($user['password'], PASSWORD_DEFAULT);
    $update = $conn->prepare("UPDATE users SET password = ? WHERE id = ?");
    $update->execute([$hashedPassword, $user['id']]);
}
echo "All passwords have been hashed.";
?>
