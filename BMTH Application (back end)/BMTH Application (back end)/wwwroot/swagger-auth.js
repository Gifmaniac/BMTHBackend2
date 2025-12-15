window.addEventListener("load", function () {

    // Wait for Swagger UI to fully initialize
    const waitForSwagger = setInterval(() => {
        if (!window.ui) return; // swagger not ready yet

        clearInterval(waitForSwagger);

        // Hide all operations until login
        function hideEverything() {
            document.querySelectorAll(".opblock").forEach(op => op.style.display = "none");
        }

        function showEverything() {
            document.querySelectorAll(".opblock").forEach(op => op.style.display = "block");
        }

        function addLoginForm() {
            const container = document.createElement("div");
            container.innerHTML = `
                <div style="padding:20px; background:#222; color:white; position:fixed; top:0; left:0; width:100%; z-index:9999;">
                    <h3>Login Required</h3>
                    <input id="email" placeholder="Email" style="margin-bottom:5px; width:300px;" />
                    <br>
                    <input id="password" placeholder="Password" type="password" style="margin-bottom:5px; width:300px;" />
                    <br>
                    <button id="loginBtn">Login</button>
                    <p id="loginError" style="color:red;"></p>
                </div>
            `;

            document.body.appendChild(container);

            document.getElementById("loginBtn").onclick = async () => {
                let email = document.getElementById("email").value;
                let password = document.getElementById("password").value;

                let res = await fetch("/api/auth/login", {
                    method: "POST",
                    headers: { "Content-Type": "application/json" },
                    body: JSON.stringify({ email, password })
                });

                let data = await res.json();

                if (!data.success) {
                    document.getElementById("loginError").innerText = data.errors?.join(", ") || data.message;
                    return;
                }

                const token = data.token;
                window.localStorage.setItem("jwt", token);

                // Inject token into swagger requests
                window.ui.getConfigs().requestInterceptor = (req) => {
                    req.headers["Authorization"] = "Bearer " + token;
                    return req;
                };

                container.remove();
                showEverything();
            };
        }

        hideEverything();
        addLoginForm();

    }, 200);

});
