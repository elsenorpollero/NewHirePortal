@page
@model NewHirePortalClean.Pages.AdminPortalModel
@{
    ViewData["Title"] = "Admin Portal";
    Layout = null; // Remove this if you want to use your main layout
}

<head>
    <link rel="stylesheet" href="~/css/formStyles.css" />
    <style>
        .container {
            display: flex;
            flex-wrap: wrap;
            gap: 20px;
            justify-content: center;
            max-width: 1200px;
            margin: 20px auto;
            padding: 20px;
        }

        .tile {
            background-color: #ffffff;
            border: 1px solid #ddd;
            border-radius: 10px;
            padding: 20px;
            width: 350px;
            box-shadow: 0 4px 6px rgba(0, 0, 0, 0.1);
            transition: transform 0.3s ease, box-shadow 0.3s ease;
            text-align: center;
        }

        .tile:hover {
            transform: translateY(-10px);
            box-shadow: 0 8px 16px rgba(0, 0, 0, 0.2);
        }

        h2 {
            text-align: center;
            color: #007bff;
            margin-bottom: 15px;
        }

        .styled-table {
            width: 100%;
            border-collapse: collapse;
            margin: 15px 0;
            font-size: 0.9em;
            box-shadow: 0 0 15px rgba(0, 0, 0, 0.1);
            table-layout: auto; /* Allow table to adjust column widths automatically */
        }

        .styled-table th, .styled-table td {
            padding: 12px 15px;
            text-align: left;
            border-bottom: 1px solid #ddd;
            word-wrap: break-word; /* Allow cell contents to wrap to prevent overflow */
        }

        .styled-table th {
            background-color: #007bff;
            color: #ffffff;
        }

        .styled-table tr:hover {
            background-color: #f1f1f1;
        }

        .form-style {
            display: flex;
            flex-direction: column;
            align-items: center;
        }

        .form-group {
            margin-bottom: 15px;
            width: 100%;
        }

        label {
            display: block;
            font-weight: bold;
            margin-bottom: 5px;
            text-align: left;
        }

        input[type="text"], input[type="password"] {
            width: 100%;
            padding: 10px;
            border: 1px solid #ccc;
            border-radius: 5px;
        }

        .button {
            background-color: #007bff;
            color: white;
            border: none;
            padding: 10px 20px;
            cursor: pointer;
            border-radius: 5px;
            font-size: 1rem;
            transition: background-color 0.3s ease;
            align-self: center;
        }

        .button:hover {
            background-color: #0056b3;
        }

        .button-link {
            color: #007bff;
            text-decoration: none;
        }

        .button-link:hover {
            text-decoration: underline;
        }
    </style>
</head>

<div class="container">
    <!-- Tile for Logged-In Users -->
    <div class="tile">
        <h2>Logged-In Users</h2>
        <table class="styled-table">
            <thead>
                <tr>
                    <th>Username</th>
                    <th>Password</th>
                    <th>Last Login</th>
                    <th>Is Admin</th>
                    <th>Actions</th> <!-- Added Actions column -->
                </tr>
            </thead>
            <tbody>
                @foreach (var user in Model.Users)
                {
                    <tr>
                        <td>@user.Username</td>
                        <td>@user.Password</td>
                        <td>@(user.LastLogin == DateTime.MinValue ? "Never" : user.LastLogin.ToString("g"))</td>
                        <td>@(user.IsAdmin ? "Yes" : "No")</td>
                        <td>
                            <a asp-page="/EditUser" asp-route-id="@user.Id" class="button-link">Edit</a> <!-- Edit link added here -->
                        </td>
                    </tr>
                }
            </tbody>
        </table>
    </div>

    <!-- Tile for Employee Applications -->
    <div class="tile">
        <h2>Employee Applications</h2>
        <table class="styled-table">
            <thead>
                <tr>
                    <th>Employee Name</th>
                    <th>Is Complete</th>
                    <th>Last Updated</th>
                    <th>Actions</th>
                </tr>
            </thead>
            <tbody>
                @foreach (var app in Model.Applications)
                {
                    <tr>
                        <td>@app.EmployeeName</td>
                        <td>@(app.IsComplete ? "Yes" : "No")</td>
                        <td>@app.LastUpdated.ToString("g")</td>
                        <td><a asp-page="/EditApplication" asp-route-id="@app.Id" class="button-link">Edit</a></td>
                    </tr>
                }
            </tbody>
        </table>
    </div>

    <!-- Tile for Adding New User -->
    <div class="tile">
        <h2>Add New User</h2>
        <form method="post" asp-page-handler="AddUser" class="form-style">
            <div class="form-group">
                <label for="newUsername">Username:</label>
                <input type="text" id="newUsername" name="newUsername" required />
            </div>
            <div class="form-group">
                <label for="newPassword">Password:</label>
                <input type="password" id="newPassword" name="newPassword" required />
            </div>
            <div class="form-group">
                <label for="isAdmin">Is Admin:</label>
                <input type="checkbox" id="isAdmin" name="isAdmin" />
            </div>
            <button type="submit" class="button">Add User</button>
        </form>
    </div>
</div>
@page
@model NewHirePortalClean.Pages.AdminPortalModel
@{
    ViewData["Title"] = "Admin Portal";
    Layout = null; // Remove this if you want to use your main layout
}

<head>
    <link rel="stylesheet" href="~/css/formStyles.css" />
    <style>
        .container {
            display: flex;
            flex-wrap: wrap;
            gap: 20px;
            justify-content: center;
            max-width: 1200px;
            margin: 20px auto;
            padding: 20px;
        }

        .tile {
            background-color: #ffffff;
            border: 1px solid #ddd;
            border-radius: 10px;
            padding: 20px;
            width: 350px;
            box-shadow: 0 4px 6px rgba(0, 0, 0, 0.1);
            transition: transform 0.3s ease, box-shadow 0.3s ease;
            text-align: center;
        }

        .tile:hover {
            transform: translateY(-10px);
            box-shadow: 0 8px 16px rgba(0, 0, 0, 0.2);
        }

        h2 {
            text-align: center;
            color: #007bff;
            margin-bottom: 15px;
        }

        .styled-table {
            width: 100%;
            border-collapse: collapse;
            margin: 15px 0;
            font-size: 0.9em;
            box-shadow: 0 0 15px rgba(0, 0, 0, 0.1);
            table-layout: auto; /* Allow table to adjust column widths automatically */
        }

        .styled-table th, .styled-table td {
            padding: 12px 15px;
            text-align: left;
            border-bottom: 1px solid #ddd;
            word-wrap: break-word; /* Allow cell contents to wrap to prevent overflow */
        }

        .styled-table th {
            background-color: #007bff;
            color: #ffffff;
        }

        .styled-table tr:hover {
            background-color: #f1f1f1;
        }

        .form-style {
            display: flex;
            flex-direction: column;
            align-items: center;
        }

        .form-group {
            margin-bottom: 15px;
            width: 100%;
        }

        label {
            display: block;
            font-weight: bold;
            margin-bottom: 5px;
            text-align: left;
        }

        input[type="text"], input[type="password"] {
            width: 100%;
            padding: 10px;
            border: 1px solid #ccc;
            border-radius: 5px;
        }

        .button {
            background-color: #007bff;
            color: white;
            border: none;
            padding: 10px 20px;
            cursor: pointer;
            border-radius: 5px;
            font-size: 1rem;
            transition: background-color 0.3s ease;
            align-self: center;
        }

        .button:hover {
            background-color: #0056b3;
        }

        .button-link {
            color: #007bff;
            text-decoration: none;
        }

        .button-link:hover {
            text-decoration: underline;
        }
    </style>
</head>

<div class="container">
    <!-- Tile for Logged-In Users -->
    <div class="tile">
        <h2>Logged-In Users</h2>
        <table class="styled-table">
            <thead>
                <tr>
                    <th>Username</th>
                    <th>Password</th>
                    <th>Last Login</th>
                    <th>Is Admin</th>
                    <th>Actions</th> <!-- Added Actions column -->
                </tr>
            </thead>
            <tbody>
                @foreach (var user in Model.Users)
                {
                    <tr>
                        <td>@user.Username</td>
                        <td>@user.Password</td>
                        <td>@(user.LastLogin == DateTime.MinValue ? "Never" : user.LastLogin.ToString("g"))</td>
                        <td>@(user.IsAdmin ? "Yes" : "No")</td>
                        <td>
                            <a asp-page="/EditUser" asp-route-id="@user.Id" class="button-link">Edit</a> <!-- Edit link added here -->
                        </td>
                    </tr>
                }
            </tbody>
        </table>
    </div>

    <!-- Tile for Employee Applications -->
    <div class="tile">
        <h2>Employee Applications</h2>
        <table class="styled-table">
            <thead>
                <tr>
                    <th>Employee Name</th>
                    <th>Is Complete</th>
                    <th>Last Updated</th>
                    <th>Actions</th>
                </tr>
            </thead>
            <tbody>
                @foreach (var app in Model.Applications)
                {
                    <tr>
                        <td>@app.EmployeeName</td>
                        <td>@(app.IsComplete ? "Yes" : "No")</td>
                        <td>@app.LastUpdated.ToString("g")</td>
                        <td><a asp-page="/EditApplication" asp-route-id="@app.Id" class="button-link">Edit</a></td>
                    </tr>
                }
            </tbody>
        </table>
    </div>

    <!-- Tile for Adding New User -->
    <div class="tile">
        <h2>Add New User</h2>
        <form method="post" asp-page-handler="AddUser" class="form-style">
            <div class="form-group">
                <label for="newUsername">Username:</label>
                <input type="text" id="newUsername" name="newUsername" required />
            </div>
            <div class="form-group">
                <label for="newPassword">Password:</label>
                <input type="password" id="newPassword" name="newPassword" required />
            </div>
            <div class="form-group">
                <label for="isAdmin">Is Admin:</label>
                <input type="checkbox" id="isAdmin" name="isAdmin" />
            </div>
            <button type="submit" class="button">Add User</button>
        </form>
    </div>
</div>
