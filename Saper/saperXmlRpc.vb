Imports CookComputing.XmlRpc

<XmlRpcUrl("http://api.sape.ru/xmlrpc/")>
Public Interface ISapeXmlRpc
    Inherits IXmlRpcProxy

    <XmlRpcMethod("sape.login", Description:="Login to sape.ru")>
    Function SapeLogin(ByVal login As String, ByVal password As String, Optional ByVal md5 As Boolean = False) As Integer

    <XmlRpcMethod("sape.get_user", Description:="Get user info")>
    Function SapeGetUser() As UserInfo

    <XmlRpcMethod("sape.get_balance_locks", Description:="Get balance locks")>
    Function SapeGetRealBalance() As XmlRpcStruct

    <XmlRpcMethod("sape.get_sites", Description:="Get sites")>
    Function SapeGetSites() As XmlRpcStruct

    <XmlRpcMethod("sape.get_categories", Description:="Get categories")>
    Function SapeGetCategories() As XmlRpcStruct()

    <XmlRpcMethod("sape.get_domain_zones", Description:="Get zones aka tlds")>
    Function SapeGetDomainTLDs() As XmlRpcStruct()

    <XmlRpcMethod("sape.get_project", Description:="Get project")>
    Function SapeGetProject(ByVal project_id As Integer) As SapeGetProject

    <XmlRpcMethod("sape.get_project_sites", Description:="Get project sites")>
    Function SapeGetProjectSites(ByVal project_id As Integer) As XmlRpcStruct()

    <XmlRpcMethod("sape.get_project_links", Description:="Get project links")>
    Function SapeGetProjectLinks(ByVal project_id As Integer) As XmlRpcStruct()

    <XmlRpcMethod("sape.project_update", Description:="Project update")>
    Function SapeUpdateProject(ByVal project_id As Integer, ByVal project_params As SapeProjectUpdateStruct) As Boolean

    <XmlRpcMethod("sape.get_sites_links_count", Description:="Get site page")>
    Function SapeGetSiteLinks(ByVal site_id As Integer) As XmlRpcStruct()

    <XmlRpcMethod("sape.get_urls", Description:="Get money site URLs")>
    Function SapeGetURLS(ByVal project_id As Integer) As XmlRpcStruct()

    <XmlRpcMethod("sape.get_url_anchors", Description:="Get pages on the desired sites")>
    Function SapeGetPagesOnSites(ByVal site_id As Integer) As XmlRpcStruct()

    <XmlRpcMethod("sape.placement_delete", Description:="Delete link")>
    Function SapeDeleteLinks(ByVal id As Double) As Boolean

    <XmlRpcMethod("sape.project_delete", Description:="Delete link")>
    Function SapeDeleteProject(ByVal project_id As Double) As Boolean

    <XmlRpcMethod("sape.get_placements_text_updates", Description:="Delete link")>
    Function SapegetTextPlacement(ByVal site_id As Double) As XmlRpcStruct()

End Interface

Public Class UserInfo
    Public Property login As String
    Public Property email As String
    Public Property balance As Double
    Public Property hash As String
    Public Property seo_nof_links_ok As Integer
    Public Property seo_nof_links As Integer
    Public Property seo_budget_monthly As Double
    Public Property seo_budget_monthly_real As Double
    Public Property amount_spent_today As Double
    Public Property amount_spent_week As Double
    Public Property amount_earned_today As Double
    Public Property amount_earned_week As Double
    Public Property amount_pc_today As Double
    Public Property amount_pc_week As Double
    Public Property amount_result_today As Double
    Public Property amount_result_week As Double
End Class

Public Class SapeProjectUpdateStruct
    Public Property name As String
    Public Property flag_cancel_links_yabl As Integer '; automatically remove links from sites that are absent in the PS Yandex,
    Public Property flag_ext_links_max_no_wl As Integer '; not subject to restrictions on the number of aircraft on the selected sites
    Public Property nof_ext_links_max_l1 As Integer '; automatically remove links to the main pages, the amount of sun on than the specified value,
    Public Property nof_ext_links_max_l2 As Integer '; automatically remove links to pages of the second shock wave, the amount of sun on than the specified value,
    Public Property nof_ext_links_max_l3 As Integer '; automatically remove links to pages of third-HC, the number of aircraft on the than the specified value,
    Public Property nof_days_to_keep_errors As Integer '; automatically remove links with the status ERROR many days in a row,
End Class

Public Class SapeGetProject
    Inherits SapeProjectUpdateStruct
    Public Property id As Integer 'ID проекта,
    Public Property amount_today As Double 'потрачено за сегодня,
    Public Property amount_yesterday As Double 'потрачено за вчера,
    Public Property amount_total As Double 'потрачено всего,
    Public Property date_created As DateTime 'дата создания,
    Public Property nof_urls As Integer 'количество урлов проекта,
    Public Property nof_pls As Integer 'количество ссылок в статусе OK.
End Class

Public Structure SiteParamsStruct
    Public Property auto As Boolean
    Public Property flag_hide_url As Boolean
    Public Property flag_use_unprintable_words_stop_list As Boolean
    Public Property flag_use_adult_words_stop_list As Boolean
    Public Property flag_use_ambiguous_words_stop_list As Boolean
    Public Property flag_reject_foreign_words As Boolean '; не принимать ссылки полностью на латинице,
    Public Property auto_activate_pages As Boolean '; автоматически активировать новые страницы,
    Public Property flag_not_for_sale As Boolean '; не принимать новые заявки на сайт,
    Public Property flag_no_dispenser_check As Boolean '; на этом сайте ссылки размещаются «вручную»,
    Public Property auto_set_prices As Boolean '; автоматически устанавливать новые цены (0 — не устанавливать,1 — средние по сайту, 2 — средние по системе умноженные на(auto_set_prices_factor), 3 — заданные вручную),
    Public Property auto_set_prices_factor As Boolean '; значение для флага "средние по системе умноженные на",
    Public Property pr_change_auto_set_prices_link As Boolean '; менять цены для текущих ссылок при изменении PR,
    Public Property pr_change_auto_set_prices As Boolean '; автоматически устанавливать новые цены при изменении PR(0 — не устанавливать,1 — средние по сайту, 2 — средние по системе умноженные на(pr_change_prices_factor), 3 — заданные вручную),
    Public Property pr_change_prices_factor As Boolean '; значение для флага "средние по системе умноженные на" при изменении PR,
    Public Property nof_placements_autostop As Boolean '; количество ссылок в статусе OK после которого следует останавливать прием заявок,
    Public Property price_context_factor_l1 As Boolean '; установка множителя цены для контекстных ссылок с главной страницы,
    Public Property price_context_factor_l2 As Boolean '; установка множителя цены для контекстных ссылок для страниц второго уровня,
    Public Property price_context_factor_l3 As Boolean '; установка множителя цены для контекстных ссылок для страниц третьего уровня,
    Public Property traf_factor As Boolean '; установка множителя цены для траффиковых страниц, цены обновляются сразу
    Public Property show_only_block As Boolean '; режим отображения ссылок (0 - смешанный, 1 - только в формате блоков),
    Public Property block_links_control As BlockLinksControlStruct '— параметры блочного отображения ссылок
End Structure

Public Structure BlockLinksControlStruct
    Public Property background_color As String ' — цвет фона,
    Public Property border_color As String ' — цвет рамки,
    Public Property header_color As String ' — цвет заголовка,
    Public Property text_color As String ' — цвет текста,
    Public Property url_color As String ' — цвет url-а,
    Public Property sign_color As String ' — цвет подписи,
    Public Property header_size As String ' — размер заголовка,
    Public Property text_size As String ' — размер текста,
    Public Property url_size As String '— размер урла,
    Public Property sign_size As String ' — размер подписи,
    Public Property border_width As String '— ширина рамки,
    Public Property border_use_radius As String '— закруглять урлы,
    Public Property text_align As String ' — выравнивание текста внутри блока,
    Public Property text_sign As String '— текст подписи,
    Public Property block_orientation As Integer '— ориентация текста внутри блока (0 вертикальная, 1 - горизонтальная),
    Public Property show_header As Boolean '— флаг показа заголовка,
    Public Property show_url As Boolean '— флаг показа урла,
    Public Property block_width_custom As String ' — ширина блока,
    Public Property css_class_prefix As String '— префикс названий классов css,
    Public Property block_no_css As Integer '— (0 - генерировать автоматически и внедрять в код страницы,1 - использовать свою таблицу стилей ),
    Public Property block_width As String ' — ширина блока ссылок,
    Public Property block_width_unit As String ' — тип измерения ширины (px или %).
End Structure

'Public Structure getSapeProjectURLsStruct
'    Public Property int As Integer
'End Structure
