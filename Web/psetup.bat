REM Following line in original script incorrectly sets all child folder permissions
REM icacls . /grant "IIS_IUSRS":(OI)(CI)M
icacls app_code /grant "IIS_IUSRS":(OI)(CI)RX
icacls app_browsers /grant "IIS_IUSRS":(OI)(CI)RX
icacls app_data /grant "IIS_IUSRS":(OI)(CI)M
icacls bin /grant "IIS_IUSRS":(OI)(CI)R
icacls config /grant "IIS_IUSRS":(OI)(CI)M
icacls css /grant "IIS_IUSRS":(OI)(CI)M
icacls data /grant "IIS_IUSRS":(OI)(CI)M
icacls masterpages /grant "IIS_IUSRS":(OI)(CI)M
icacls media /grant "IIS_IUSRS":(OI)(CI)M
icacls python /grant "IIS_IUSRS":(OI)(CI)M
icacls scripts /grant "IIS_IUSRS":(OI)(CI)M
icacls macroscripts /grant "IIS_IUSRS":(OI)(CI)M
icacls umbraco /grant "IIS_IUSRS":(OI)(CI)R
icacls usercontrols /grant "IIS_IUSRS":(OI)(CI)R
icacls xslt /grant "IIS_IUSRS":(OI)(CI)M
icacls web.config /grant "IIS_IUSRS":(OI)(CI)M
icacls web.config /grant "IIS_IUSRS":M
REM If you have installed the Robots.txt editor package you need the following line too
icacls robots.txt /grant "IIS_IUSRS":M
