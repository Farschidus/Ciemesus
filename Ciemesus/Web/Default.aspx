<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="Default" %>

<!DOCTYPE html>
<html lang="en">
<head>
	<title>Coming Soon</title>
	<meta charset="UTF-8">
	<meta name="viewport" content="width=device-width, initial-scale=1">
	<link rel="icon" type="image/png" href="Client/Images/favicon.ico"/>
	<link rel="stylesheet" type="text/css" href="/client/static/dist/css/underConstruction.min.css?<%= DateTime.UtcNow.ToString("yyyyMMddHHmmss") %>" />
</head>
<body>
	<div class="bg-img1 size1 overlay1 p-t-24" style="background-image: url('Client/Images/Public/underConstruction.jpg');">
		<div class="flex-w flex-sb-m p-l-80 p-r-74 p-b-175 respon5">
			<div class="wrappic1 m-r-30 m-t-10 m-b-10">
				<a href="http://ciemesus.com" target="_blank"><img id="ciemesus" src="Application/Images/General/CiemesusLogo.png" alt="Ciemesus"></a>
			</div>

			<div id="Social" class="flex-w m-t-10 m-b-10">
				<a href="#" class="size3 flex-c-m how-social trans-04 m-r-6">
					<i class="fa fa-facebook"></i>
				</a>

				<a href="#" class="size3 flex-c-m how-social trans-04 m-r-6">
					<i class="fa fa-twitter"></i>
				</a>

				<a href="#" class="size3 flex-c-m how-social trans-04 m-r-6">
					<i class="fa fa-youtube-play"></i>
				</a>
			</div>
		</div>

		<div class="flex-w flex-sa p-r-200 respon1">
			<div class="p-t-34 p-b-60 respon3">
				<p class="l1-txt1 p-b-10 respon2">
					<%= Farschidus.Configuration.ConfigurationManager.Settings.GetItemAttribute("Website", "Name", "langCode", Global.MethodsAndProps.CurrentLanguageCode) %> website is
				</p>

				<h3 class="l1-txt2 p-b-45 respon2 respon4">
					Coming Soon
				</h3>

				<div class="cd100"></div>

			</div>

			<div id="NotifyMe" class="bg0 wsize1 bor1 p-l-45 p-r-45 p-t-50 p-b-18 p-lr-15-sm">
				<h3 class="l1-txt3 txt-center p-b-43">
					Newsletter
				</h3>

				<form class="w-full validate-form">

					<div class="wrap-input100 validate-input m-b-10" data-validate = "Name is required">
						<input class="input100 placeholder0 s1-txt1" type="text" name="name" placeholder="Name">
						<span class="focus-input100"></span>
					</div>

					<div class="wrap-input100 validate-input m-b-20" data-validate = "Valid email is required: ex@abc.xyz">
						<input class="input100 placeholder0 s1-txt1" type="text" name="email" placeholder="Email">
						<span class="focus-input100"></span>
					</div>
					
					<button class="flex-c-m size2 s1-txt2 how-btn1 trans-04">
						Subscribe
					</button>
				</form>

				<p class="s1-txt3 txt-center p-l-15 p-r-15 p-t-25">
					And don’t worry, we hate spam too! You can unsubcribe at anytime.
				</p>
			</div>
		</div>
	</div>
	<script type="text/javascript" src="/client/static/dist/js/underConstruction.min.js?<%= DateTime.UtcNow.ToString("yyyyMMddHHmmss") %>"></script>
	<script>
		$('.cd100').countdown100({
			/*Set Endtime here; Endtime must be > current time*/
			endtimeYear: 0,
			endtimeMonth: 0,
			endtimeDate: 31,
			endtimeHours: 15,
			endtimeMinutes: 7,
			endtimeSeconds: 3,
			timeZone: "" 
			// ex:  timeZone: "America/New_York"
			//go to " http://momentjs.com/timezone/ " to get timezone
		});
	</script>
</body>
</html>