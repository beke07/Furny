using Furny.Models;
using Furny.ServiceInterfaces;
using Furny.Services;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Xunit;

namespace Furny.Test
{
    public class NotificationTest : MongoDbTest
    {
        private readonly INotificationService _notificationService;
        private readonly IPanelCutterService _panelCutterService;

        public NotificationTest()
        {
            _notificationService = new NotificationService(_mapper, _configuration);
            _panelCutterService = new PanelCutterService(_mapper, _configuration);
        }

        [Fact]
        public async Task CreateNotificationTest()
        {
            var panelCutter = (await _panelCutterService.Get()).First();

            panelCutter.Notifications = new List<Notification>();
            await _panelCutterService.UpdateAsync(panelCutter);

            await _notificationService.CreateNotificationAsync(panelCutter.Id.ToString(), new Notification()
            {
                Text = "Hej hej hej!"
            });

            panelCutter = (await _panelCutterService.Get()).First();
            var notification = panelCutter.Notifications.ElementAt(0);
            
            Assert.NotNull(notification);
            Assert.True(notification.Text == "Hej hej hej!");
        }

        [Fact]
        public async Task DoneNotificationTest()
        {
            await CreateNotificationTest();

            var panelCutter = (await _panelCutterService.Get()).First();
            var notification = panelCutter.Notifications.ElementAt(0);

            await _notificationService.DoneNotificationAsync(panelCutter.Id.ToString(), notification.Id.ToString());

            panelCutter = (await _panelCutterService.Get()).First();

            Assert.True(panelCutter.Notifications.ElementAt(0).IsDone);
        }

        [Fact]
        public async Task GetNotificationTest()
        {
            await CreateNotificationTest();

            var panelCutter = (await _panelCutterService.Get()).First();
            var result = await _notificationService.GetNotificationsAsync(panelCutter.Id.ToString());

            Assert.True(result.Count == panelCutter.Notifications.Count);
        }
    }
}
